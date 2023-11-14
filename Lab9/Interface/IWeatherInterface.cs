using Lab9.Models.WeatherModel;

namespace Lab9.Interface
{
    public interface IWeatherInterface
    {
        Task<WeatherResponse> GetWeather(string city);
    }
}
