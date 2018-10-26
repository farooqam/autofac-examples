using System;
using AutofacExamples.Services;

namespace ServiceHost
{
    public class WeatherServiceWorker : IServiceWorker
    {
        private readonly IWeatherService _weatherService;

        public WeatherServiceWorker(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public void Run()
        {
            WeatherResponseModel response = _weatherService.GetWeather(
                new WeatherRequestModel {City = "Seattle"});

            OnData?.Invoke(response);
        }

        public Action<object> OnData { get; set; }
    }
}
