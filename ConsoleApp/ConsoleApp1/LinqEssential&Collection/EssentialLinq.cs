using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1.LinqEssential
{
    class EssentialLinq
    {
        public static void Collection()
        {
            // Distionary
            Dictionary<string, string> car = new Dictionary<string, string>();
            car.Add("Model", "Hyundai");
            car.Add("Price", "36K");

            // iterate through the car dictionary 
            foreach (KeyValuePair<string, string> items in car)
            {
                Console.WriteLine("{0} : {1}", items.Key, items.Value);
            }

        }
        public EssentialLinq()
        {
            Collection();
            // select - JS map
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNumbers = from num in numbers
                              where num % 2 == 0
                              select num;

            foreach (var even in evenNumbers)
            {
                Console.WriteLine(even);
            }

            var squares = numbers.Select(num => num * num);
            Console.WriteLine("Squares of Numbers:");
            foreach (var square in squares)
            {
                Console.WriteLine(square);
            }

            // where - JS filter
            var filtered = numbers.Where(n => n > 5).ToList();
            Console.WriteLine("Numbers greater than 5:");
            filtered.ForEach(n => Console.WriteLine(n));

            // orderby - JS sort
            var sortedNumbers = from num in numbers
                                orderby num descending
                                select num;

            // groupby - JS reduce
        }
    }

    // https://www.youtube.com/watch?v=71qFZUyKCy0
    /* Linq Query and Method Syntax
     * 1. where - Filters a sequence of values based on a predicate.
     * 2. select - Projects each element of a sequence into a new form.
     * 3. orderby - Sorts the elements of a sequence in ascending or descending order.
     * 4. groupby - Groups the elements of a sequence according to a specified key.
     * 
     * Deferred Execution: Many LINQ operations use deferred execution, 
     * meaning the query is not executed until its results are actually needed, 
     * which can improve performance in some scenarios.
     * 
     * Collection:
     * List<T>
     * Array
     * Dictionary<TKey, TValue>
     * HashSet<T>
     * Queue<T>
     * Stack<T>
     */
}
