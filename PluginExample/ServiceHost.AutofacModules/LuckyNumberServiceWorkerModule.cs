using System;
using System.Configuration;
using Autofac;
using AutofacExamples.ServiceHost.Workers;
using AutofacExamples.Services;

namespace AutofacExamples.ServiceHost.AutofacModules
{
    public class LuckyNumberServiceWorkerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
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

            builder.RegisterInstance(worker).As<IServiceWorker>().SingleInstance();

        }
    }
}
