using Lab9.Models.WeatherModel;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Lab9.Interface
{
    public class WForecastRepository : IWeatherInterface
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WForecastRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<WeatherResponse> GetWeather(string city)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={_configuration.GetSection("API_KEY").Value}");
           if(response.IsSuccessStatusCode)
            {
                var weather = await response.Content.ReadFromJsonAsync<WeatherResponse>();
                return weather;
            }
          
            return null;
        }
    }
}
