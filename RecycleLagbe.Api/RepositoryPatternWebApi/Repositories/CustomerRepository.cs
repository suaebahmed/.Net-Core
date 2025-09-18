﻿using RepositoryPatternWebApi.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWebApi.Data;

namespace RepositoryPatternWebApi.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ECommerceDbContext _context;
        public CustomerRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}