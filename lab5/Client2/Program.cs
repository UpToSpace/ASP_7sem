using Client2.ServiceReference1;
using System;
using WCF;

namespace Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client service1Client = new Service1Client();

            var sumResult = service1Client.Sum(
                new A { s = "hello ", k = 4, f = 1.7f },
                new A { s = "hi", k = 8, f = 1.3f }
                );

            Console.WriteLine($"Sum\nf = {sumResult.f}\nk = {sumResult.k}\ns = {sumResult.s}");
            Console.WriteLine($"\n\nConcat\nresult = " + service1Client.Concat(sumResult.s, sumResult.f));
            Console.WriteLine($"\n\nAdd\nresult = " + service1Client.Add(sumResult.k, sumResult.k));

            service1Client.Close();

            Console.ReadKey();
        }
    }
}
