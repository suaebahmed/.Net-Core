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
        public string name { get; set; }
        public int age;

        protected Motorcycle(string name)
        {
            this.name = name;
        }

        public void StartEngine() {/* Method statements here */ }

        protected void AddGas(int gallons) { /* Method statements here */ }

        public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

        public abstract double GetTopSpeed();
    }
    class Honda : Motorcycle
    {
        public Honda(string name) : base(name)
        {
            age = 18;
        }

        public override double GetTopSpeed()
        {
            return 200;
        }
    }

    interface IMotorcycle
    {
        void StartEngine();
        void AddGas(int gallons);
        int Drive(int miles, int speed);
        double GetTopSpeed();
    }
    class Yamaha : IMotorcycle
    {
        public string name { get; set; }
        public int age;
        public Yamaha(string name)
        {
            this.name = name;
            age = 20;
        }
        public void StartEngine() { /* Method statements here */ }
        public void AddGas(int gallons) { /* Method statements here */ }
        public int Drive(int miles, int speed) { /* Method statements here */ return 1; }
        public double GetTopSpeed()
        {
            return 180;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Property name: {name}");
            Console.WriteLine($"Field age: {age}");
            Console.WriteLine($"Yamaha top speed: {GetTopSpeed()} mph");
        }
    }
    public DataAbstraction()
    {
        //var honda = new Honda("Passed");
        //Console.WriteLine($"Property name: {honda.name}");
        //Console.WriteLine($"Field age: {honda.age}");
        //Console.WriteLine($"Honda top speed: {honda.GetTopSpeed()} mph");

        Yamaha yamaha = new Yamaha("Failed");
        Console.WriteLine($"Property name: {yamaha.name}");
        Console.WriteLine($"Field age: {yamaha.age}");
        Console.WriteLine($"Yamaha top speed: {yamaha.GetTopSpeed()} mph");
        //yamaha.DisplayInfo();


        //  In C#, you can only access members declared on the static type (the interface)
        IShape shape = new Circle(5);
        Console.WriteLine($"Circle area: {shape.GetArea()}");
        Console.WriteLine($"Circle Radius: {shape.Radius}");
    }
    interface IShape
    {
        public double Radius { get; set; }
        double GetArea();
        void Draw();
    }
    class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
        public void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {Radius}");
        }
    }
}

