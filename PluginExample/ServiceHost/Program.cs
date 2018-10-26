using System;
using System.Configuration;
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
                WeatherServiceWorkerSettings settings = new WeatherServiceWorkerSettings
                {
                    City = ConfigurationManager.AppSettings["city"]
                };

                IWeatherService weatherService = new WeatherService();
                
                IServiceWorker worker = new WeatherServiceWorker(weatherService, settings)
                {
                    OnData = (data) => Console.WriteLine(JsonConvert.SerializeObject(data))
                };

                worker.Run();
            }
            else if (mode == "n")
            {
                LuckyNumberServiceSettings settings = new LuckyNumberServiceSettings
                {
                    Min = Convert.ToInt32(ConfigurationManager.AppSettings["min"]),
                    Max = Convert.ToInt32(ConfigurationManager.AppSettings["max"])
                };

                ILuckyNumberService luckyNumberService = new LuckyNumberService(settings);

                IServiceWorker worker = new LuckyNumberServiceWorker(luckyNumberService)
                {
                    OnData = Console.WriteLine
                };

                worker.Run();
            }
        }
    }
}
