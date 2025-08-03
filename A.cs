using System;
namespace AutoMapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create and Populate Employee Object i.e. Source Object
            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT"
            };

            //Initializing AutoMapper
            var mapper = MapperConfig.InitializeAutomapper();

            //Way1: Specify the Destination Type and to The Map Method pass the Source Object
            //Now, empDTO1 object will having the same values as emp object
            var empDTO1 = mapper.Map<EmployeeDTO>(emp);

            //Way2: Specify the both Source and Destination Type 
            //and to The Map Method pass the Source Object
            //Now, empDTO2 object will having the same values as emp object
            var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);

            Console.WriteLine("Name: " + empDTO1.Name + ", Salary: " + empDTO1.Salary + ", Address: " + empDTO1.Address + ", Department: " + empDTO1.Department);
            Console.ReadLine();
        }
    }
}


namespace AutoMapperDemo
{
    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }
}

namespace AutoMapperDemo
{
    public class EmployeeDTO
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }
}