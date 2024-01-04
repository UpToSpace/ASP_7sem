using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PWS_7_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(PWS_7.Feed1));
            host.Open();
            Console.WriteLine("Host Open");
            var s = Console.ReadLine();
        }
    }
}
