using System;

namespace ConsoleApp1
{
    class MethodInCSharp
    {
        public MethodInCSharp(int x)
        {
            Func<int, int> square = delegate (int x) { return x * x; };
            Console.WriteLine(square(10));
            if(x > 10) throw new Exception("x should be less than or equal to 10");

            Console.WriteLine("MethodInCSharp instance created.");

        }
    }

    abstract class Motorcycle
    {
        public void StartEngine() {/* Method statements here */ }

        protected void AddGas(int gallons) { /* Method statements here */ }

        // Derived classes can override the base class implementation.
        public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

        // Derived classes must implement this.
        public abstract double GetTopSpeed();
    }   
    class Honda : Motorcycle
    {
        public override double GetTopSpeed()
        {
            return 200; // Example implementation
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //var lambda = new LambdaExpressionAndAnonymousFun();
            var md = new MethodInCSharp(110);
            var honda = new Honda();
            Console.WriteLine($"Honda top speed: {honda.GetTopSpeed()} mph");


        }
    }
    public class LambdaExpressionAndAnonymousFun
    {
        public LambdaExpressionAndAnonymousFun()
        {
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(10));

            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squaredNumbers)); // 4 9 16 25


            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("World");

            // Discard one or more parameters
            Func<int, int, int> add = (x, _) => x + 10;


            var sum = (IEnumerable<int> values) =>
            {
                int sum = 0;
                foreach (var value in values)
                    sum += value;

                return sum;
            };
            var sequence = new[] { 1, 2, 3, 4, 5 };
            var total = sum(sequence);
            Console.WriteLine(total); // 15

            //Async lambdas


            // Lambda expression and tuples
            Func<(int, int, int), (int, int, int)> doubleThem = tp => (tp.Item1 * 2, tp.Item2 * 2, tp.Item3 * 2);
            var numbersTuple = (1, 2, 3);
            var result = doubleThem(numbersTuple);
            Console.WriteLine($"The set {numbersTuple} doubled is {result}");

            // Lambdas with the standard query operators
        }
    }
}