using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Autofac;
using Autofac.Configuration;
using AutofacExamples.ServiceHost.Workers;
using AutofacExamples.Services;
using Newtonsoft.Json;

namespace ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            ConfigurationSettingsReader reader = new ConfigurationSettingsReader();

            builder.RegisterModule(reader);

            IContainer container = builder.Build();
            IEnumerable<IServiceWorker> workers = container.Resolve<IEnumerable<IServiceWorker>>().ToList();

            if (!workers.Any())
            {
                Console.WriteLine("No worker modules are registered so there is nothing to do.");
                return;
            }

            foreach (var worker in workers)
            {
                worker.OnData = (data) => Console.WriteLine(JsonConvert.SerializeObject(data));
                worker.Run();
            }

        }
    }
}
