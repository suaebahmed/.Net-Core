using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Coupling;
public class LooseCoupling
{
    public interface IEngine
    {
        string Start();
    }
    public class PetrolEngine : IEngine
    {
        public string Start()
        {
            return "Petrol engine started.";
        }
    }
    public class ElectricEngine : IEngine
    {
        public string Start()
        {
            return "Electric engine started silently.";
        }
    }
    public class Car
    {
        private IEngine _engine; // Loosely coupled to IEngine interface

        public Car(IEngine engine) // Dependency Injected
        {
            _engine = engine;
        }

        public string StartCar()
        {
            return _engine.Start();
        }
    }
    public LooseCoupling()
    {
        //var res = new Car(new PetrolEngine()).StartCar();
        var res = new Car(new ElectricEngine()).StartCar();
        Console.WriteLine(res);
    }
}
