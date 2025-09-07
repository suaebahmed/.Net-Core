using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Models;

namespace ConsoleApp2.Repositories
{
    public interface IEmployeeCommandsRepository
    {
        void SaveEmployee(Employee employee);
    }
}