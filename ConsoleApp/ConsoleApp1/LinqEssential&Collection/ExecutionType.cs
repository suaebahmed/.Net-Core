using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LinqEssential_Collection
{
    public class ExecutionType
    {
        public ExecutionType()
        {
            List<int> list = new List<int>()
            {
                10, 20, 30, 5
            };

            // Deferred Execution: The query is defined, but its execution is delayed until its results are actually needed or iterated over.
            var listFilter = list.Where(x =>
            {
                Console.WriteLine($"Processing {x}");
                return x > 10;
            });

            // Immediate Execution: The query is executed at the point of its declaration, and the results are stored in memory immediately. 
            var listFilterWithToList = list.Where(x =>
            {
                Console.WriteLine($"Processing in ToList {x}");
                return x > 10;
            }).ToList();


            list.Add(15);

            foreach (var x in listFilter)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("-----------------");

            foreach (var x in listFilterWithToList)
            {
                Console.WriteLine(x);
            }
        }
    }
}
