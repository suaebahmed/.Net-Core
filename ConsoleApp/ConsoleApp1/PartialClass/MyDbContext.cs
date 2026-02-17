using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.partial_class
{
    public partial class MyDbContext
    {
        public MyDbContext()
        {
            Console.WriteLine("This is the Core DB Context");
        }
    }
}
