using FluentValidation;
using Microsoft.EntityFrameworkCore;
//using RandomService.NumberService;
using RepositoryPatternWebApi.Data;
using RepositoryPatternWebApi.DTOs;
//using RepositoryPatternWebApi.Middleware;
using RepositoryPatternWebApi.Repositories;
using RepositoryPatternWebApi.Repositories.Implementations;
using RepositoryPatternWebApi.Validators;

namespace RepositoryPatternWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Register the Services
            builder.Services.AddControllers()
             .AddJsonOptions(options =>
             {
                 // Disabled Camel Case in JSON serialization and deserialization
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
             });

            // Register ECommerceDbContext
            // By default it will be a Scopped Service
            builder.Services.AddDbContext<ECommerceDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDBConnection"))
            );

            // builder.Services.AddSingleton<INumberService, NumberService>();
            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<IValidator<ProductDTO>, ProductCreateDTOValidator>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline. Middleware!!
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            //app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();

            // MAP controller and get request
            app.MapControllers();
            app.MapGet("/", () => "Hello World, Ecommerce Web API Is Running!");

            app.Run();
        }
    }
}