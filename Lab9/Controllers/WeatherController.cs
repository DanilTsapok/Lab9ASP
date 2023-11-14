using Lab9.Interface;
using Lab9.Models;
using Lab9.Models.WeatherModel;
using Microsoft.AspNetCore.Mvc;

namespace Lab9.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherInterface _weatherInterface;

        public WeatherController(IWeatherInterface weatherInterface)
        {
            _weatherInterface = weatherInterface;
        }
        [HttpGet]
        public IActionResult SearchByCity()
        {
            var viewModel = new SearchByCity();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SearchByCity(SearchByCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Weather", new { city = model.CityName });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> City(string city) { 
            WeatherResponse weatherResponse = await _weatherInterface.GetWeather(city);
            City viewModel = new City();
            if(weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Temperature = weatherResponse.Main.Temp;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
            }
        
            return View(viewModel);
        }
    }
}
