﻿using PumpClient.PumpServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PumpClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());

            PumpServiceClient pumpServiceClient = new PumpServiceClient(instanceContext);

            pumpServiceClient.CompileScript();
            pumpServiceClient.RunScript();

            Console.ReadKey();

            pumpServiceClient.Close();
        }
    }
}
