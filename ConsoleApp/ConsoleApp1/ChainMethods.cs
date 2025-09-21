using System;
using System.Security.AccessControl;

namespace ConsoleApp1;

public class ChainMethods
{
    public ChainMethods()
    {
        Method1().Method2().Method3();
        Console.WriteLine("Chained methods completed.\n");

        var result = Method3().Method2().Method1();
        Console.WriteLine($"Result: {result}");
    }
    public ChainMethods Method1()
    {
        Console.WriteLine("Inside Method1");
        return this;
    }
    public ChainMethods Method2()
    {
        Console.WriteLine("Inside Method2");
        return this;
    }
    public ChainMethods Method3()
    {
        Console.WriteLine("Inside Method3");
        return this;
    }
}
