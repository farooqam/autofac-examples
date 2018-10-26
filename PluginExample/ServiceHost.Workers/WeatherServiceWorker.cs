using System;
using AutofacExamples.Services;

namespace AutofacExamples.ServiceHost.Workers
{
    public class WeatherServiceWorkerSettings
    {
        public string City { get; set; }
    }

    public class WeatherServiceWorker : IServiceWorker
    {
        private readonly IWeatherService _weatherService;
        private readonly WeatherServiceWorkerSettings _settings;

        public WeatherServiceWorker(IWeatherService weatherService, WeatherServiceWorkerSettings settings)
        {
            _weatherService = weatherService;
            _settings = settings;
        }

        public void Run()
        {
            WeatherResponseModel response = _weatherService.GetWeather(
                new WeatherRequestModel {City = _settings.City});

            OnData?.Invoke(response);
        }

        public Action<object> OnData { get; set; }
    }
}
