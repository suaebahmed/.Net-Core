using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Commands;
using ConsoleApp2.Repositories;
using ConsoleApp2.Queries;

// CQRS Pattern - Command Query Responsibility Segregation
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var EmployeeCommands = new EmployeeCommands(new EmployeeCommandsRepository());
            EmployeeCommands.SaveEmployeeData(new Models.Employee
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Street = "123 Main St",
                City = "Anytown",
                PostalCode = "12345"
            });
            Console.WriteLine("Employee data saved successfully.");

            var EmployeeQueries = new EmployeeQueries(new EmployeeQueriesRepository());
            var employee = EmployeeQueries.FindByID(1);
            Console.WriteLine($"Employee Details: ID={employee.Id}, Name={employee.FullName}, Address={employee.Address}, Age={employee.Age}");

        }
    }
}
