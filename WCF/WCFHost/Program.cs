﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(WCFService.ServiceImpl));
            host.Open();

            Console.WriteLine("Host worked");
            Console.ReadLine();
        }
    }
}
