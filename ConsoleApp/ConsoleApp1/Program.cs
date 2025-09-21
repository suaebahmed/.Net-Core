using System;
using ConsoleApp1.Coupling;

namespace ConsoleApp1;
class Program
{
    static void Main(string[] args)
    {
        //var dataAbstraction = new DataAbstraction();
        //var lambda = new LambdaExpressionAndAnonymousFun();
        //var genericClass = new LearningGenerics();
        //var loose = new LooseCoupling();
        var tight = new TightCoupling();


        //var delegatesAndEvents = new DelegatesAndEvents();
        //var chain = new ChainMethods();
    }
}
