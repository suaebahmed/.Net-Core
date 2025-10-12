using System;
using System.Security.Cryptography;
using System.Text;
using ConsoleApp1.Coupling;
using ConsoleApp1.Json;
using ConsoleApp1.LinqEssential;
using ConsoleApp1.NewFeatures;

namespace ConsoleApp1;
class Program
{
    public class Solve
    {
        public Solve()
        {
            byte[] data = MD5.HashData(Encoding.UTF8.GetBytes("Hello World"));
            Console.WriteLine(Convert.ToHexString(data));

            using(MD5 md5 = MD5.Create())
            {
                data = md5.ComputeHash(Encoding.UTF8.GetBytes("Hello World"));

                StringBuilder sBuilder = new StringBuilder();
                for(int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("X2"));
                }
                Console.WriteLine(sBuilder.ToString());
            }

            string s = "Hello World";
            Console.WriteLine(s.GetHashCode().ToString());
        }
    }
    static void Main(string[] args)
    {
        Solve s = new Solve();
        //_ = new DataAbstraction();
        //_ = new LambdaExpressionAndAnonymousFun();
        //_ = new LearningGenerics();
        //_ = new LooseCoupling();
        //_ = new TightCoupling();
        //_ = new JsonSerializeAndDeserialize();
        //_ = new EssentialLinq();
        //_ = new Features1(); // enum, switch expression
        //_ = new DataTypesCharp();


        //_ = new DelegatesAndEvents();
        //_ = new ChainMethods();
    }
}
