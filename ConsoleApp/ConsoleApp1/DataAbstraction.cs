using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

public class DataAbstraction
{
    abstract class Motorcycle
    {
        public void StartEngine() {/* Method statements here */ }

        protected void AddGas(int gallons) { /* Method statements here */ }

        public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

        public abstract double GetTopSpeed();
    }
    class Honda : Motorcycle
    {
        public override double GetTopSpeed()
        {
            return 200;
        }
    }
    public DataAbstraction()
    {
        var honda = new Honda();
        Console.WriteLine($"Honda top speed: {honda.GetTopSpeed()} mph");

    }
}

