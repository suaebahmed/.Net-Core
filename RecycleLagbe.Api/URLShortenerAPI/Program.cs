using Microsoft.EntityFrameworkCore;
using URLShortenerAPI.Data;
using URLShortenerAPI.Service.Counter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
 .AddJsonOptions(options =>
 {
     // Disabled Camel Case in JSON serialization and deserialization
     options.JsonSerializerOptions.PropertyNamingPolicy = null;
 });

builder.Services.AddDbContext<URLShortenerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDBConnection"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register CounterService as a singleton
builder.Services.AddSingleton<CounterService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
