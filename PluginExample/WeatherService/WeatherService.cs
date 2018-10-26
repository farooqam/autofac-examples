using System;

namespace AutofacExamples.Services
{
    public interface IWeatherService
    {
        WeatherResponseModel GetWeather(WeatherRequestModel model);
    }

    public class WeatherResponseModel
    {
        public string City { get; set; }
        public int TempF { get; set; }
    }

    public class WeatherRequestModel
    {
        public string City { get; set; }
    }

    public class WeatherService : IWeatherService
    {
        public WeatherResponseModel GetWeather(WeatherRequestModel model)
        {
            return new WeatherResponseModel
            {
                City = model.City,
                TempF = new Random().Next(20, 80)
            };
        }
    }
}
