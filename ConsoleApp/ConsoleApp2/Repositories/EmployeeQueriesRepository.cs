using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Models;

namespace ConsoleApp2.Repositories
{
    public class EmployeeQueriesRepository : IEmployeeQueriesRepository
    {
        // Get the employee record from a data store || Below is for demo purposes only
        public Employee GetByID(int employeeID)
        {
            return new Employee()
            {
                Id = 100,
                FirstName = "John",
                LastName = "Smith",
                DateOfBirth = new DateTime(2000, 1, 1),
                Street = "100 Toronto Street",
                City = "Toronto",
                PostalCode = "k1k 1k1"
            };
        }
    }
}
