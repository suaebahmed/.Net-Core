using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Coupling;
public class TightCoupling
{
    public class PetrolEngine
    {
        public string Start()
        {
            return "Petrol engine started.";
        }
    }
    public class ElectricEngine
    {
        public string Start()
        {
            return "Electric engine started silently.";
        }
    }
    public class Car
    {
        private PetrolEngine _engine; // Tightly coupled to PetrolEngine
        public Car()
        {
            _engine = new PetrolEngine(); // Direct instantiation
        }
        public string StartCar()
        {
            return _engine.Start();
        }
    }
    public TightCoupling()
    { 
        var res = new Car().StartCar();
        Console.WriteLine(res);
    }
}
