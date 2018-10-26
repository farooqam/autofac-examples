using System;
using System.Configuration;
using Autofac;
using AutofacExamples.ServiceHost.Workers;
using AutofacExamples.Services;
using Newtonsoft.Json;

namespace AutofacExamples.ServiceHost.AutofacModules
{
    public class WeatherServiceWorkerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
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

            builder.RegisterInstance(worker).As<IServiceWorker>().SingleInstance();
        }
    }
}
