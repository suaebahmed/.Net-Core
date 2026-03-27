
## Scaffolding Commands

Scaffold-DbContext -Connection Name=BookStoresDBConnection Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context BookStoresDBContext


# EF Core Query Shape: Navigating from Different Sides of a Relationship

```bash
    public IEnumerable<MerchantCheckoutAllowedHost> GetMerchantCheckoutAllowedHost(string merchantClientId) =>
        this.Merchants
            .Include(m => m.MerchantCheckoutAllowedHosts)
            .Where(m =>
                m.AzureEntraClientId == merchantClientId &&
                m.IsActive)
            .FirstOrDefault()?
                .MerchantCheckoutAllowedHosts
                .Where(mcah => mcah.IsActive);

    public async Task<List<MerchantCheckoutAllowedHost>> GetListAsync(long merchantId)
    {
        return await Context.MerchantCheckoutAllowedHosts
            .Where(mcah => mcah.MerchantId == merchantId && mcah.IsActive && mcah.Merchant.IsActive)
            .ToListAsync();
    }
```

### Query 1: `GetMerchantCheckoutAllowedHost`

```sql
SELECT mcah.*
FROM Merchants m
INNER JOIN MerchantCheckoutAllowedHosts mcah ON mcah.MerchantId = m.Id
WHERE m.AzureEntraClientId = @merchantClientId
  AND m.IsActive = 1
  AND mcah.IsActive = 1;
```

---

### Query 2: `GetListAsync`

```sql
SELECT mcah.*
FROM MerchantCheckoutAllowedHosts mcah
INNER JOIN Merchants m ON m.Id = mcah.MerchantId
WHERE mcah.MerchantId = @merchantId
  AND mcah.IsActive = 1
  AND m.IsActive = 1;
```

---

### Key Differences Between the Two

| | Query 1 | Query 2 |
|---|---|---|
| **Filter** | By `AzureEntraClientId` (string) | By `MerchantId` (long) |
| **Entry point** | Starts from `Merchants` table | Starts from `MerchantCheckoutAllowedHosts` table |
| **Behavior if no merchant** | Returns `null` (the `?.` operator) | Returns empty list |
| **Execution** | Synchronous | Async |

Both produce the same **JOIN shape** — the difference is just the starting table and the WHERE filter. 
EF Core is smart enough to generate the same `INNER JOIN` regardless of which side you navigate from.



# Async Method Style: `async/await` vs Direct Task Return
Because this method is just **forwarding** one async EF Core call:

- `FirstOrDefaultAsync()` already returns `Task<ProcessorRule>`.
- Your method also returns `Task<ProcessorRule>`.

So wrapping it with `async/await` adds no value.

```csharp
public Task<ProcessorRule> GetProcessorRuleTypeAsync(...) =>
    GetProcessorRuleQuery(...).FirstOrDefaultAsync();
```

is equivalent (for normal use) to:

```csharp
public async Task<ProcessorRule> GetProcessorRuleTypeAsync(...)
{
    return await GetProcessorRuleQuery(...).FirstOrDefaultAsync();
}
```

Use `async/await` only when you need extra logic around the await, e.g.:

- `try/catch` around awaited call
- multiple awaits
- transform result after await
- `using`/`await using` scope behavior
- custom cancellation/timeout orchestration

For a single pass-through query, returning the task directly is cleaner and slightly more efficient (no generated async state machine).


# EF Core Loading Strategies: Eager, Lazy, and Explicit
Here's the core idea: **eager loading** fetches related data in a single query upfront, while **lazy loading** fetches it automatically on demand (extra queries triggered later). There's also **explicit loading** as a middle ground.

### Eager loading — `.Include()`

This is what your code already uses. It tells EF Core: *"when you fetch the Merchant, also JOIN and fetch its `MerchantCheckoutAllowedHosts` in the same SQL query."* One trip to the database, all data comes back together.

```csharp
this.Merchants
    .Include(m => m.MerchantCheckoutAllowedHosts)  // ← eager load
    .Where(...)
```

### Lazy loading — `virtual` + proxies

You mark navigation properties as `virtual`. EF Core wraps your entity in a proxy class at runtime, and the moment your code *accesses* `.MerchantCheckoutAllowedHosts`, it silently fires another SQL query behind the scenes.

```csharp
public class Merchant {
    public virtual ICollection<MerchantCheckoutAllowedHost> Hosts { get; set; }
    //     ↑ virtual makes it lazy-loadable
}
```

The danger is the **N+1 problem** — if you loop over 100 merchants and access `.Hosts` on each, you get 101 queries. It's invisible in the code, which makes it easy to miss.

### Explicit loading — `.LoadAsync()`

A middle ground. You fetch the merchant first, then manually trigger a second query for the related data when you decide you need it.

```csharp
var merchant = await ctx.Merchants.FindAsync(id);

// Later, only if needed:
await ctx.Entry(merchant)
    .Collection(m => m.Hosts)
    .LoadAsync();
```

---

**For your codebase**: stick with eager loading (`.Include()`). It's explicit, predictable, and 
maps cleanly to the SQL JOIN — which is exactly what you already saw when converting your queries.