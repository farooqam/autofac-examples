using System;
using AutofacExamples.Services;
using Newtonsoft.Json;

namespace ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("USAGE: ServiceHost [mode = W | N");
                return;
            }

            string mode = args[0].ToLowerInvariant();

            if (mode == "w")
            {
                WeatherServiceWorker worker = new WeatherServiceWorker(new WeatherService())
                {
                    OnData = (data) => Console.WriteLine(JsonConvert.SerializeObject(data))
                };

                worker.Run();
            }
            else if (mode == "n")
            {
                LuckyNumberServiceWorker worker = new LuckyNumberServiceWorker(new LuckyNumberService())
                {
                    OnData = Console.WriteLine
                };

                worker.Run();
            }
        }
    }
}
