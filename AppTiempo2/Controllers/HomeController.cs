using AppTiempo2.Models;
using Microsoft.AspNetCore.Mvc;
using OpenWeatherMap.Standard;
using OpenWeatherMap.Standard.Models;
using System.Diagnostics;

namespace AppTiempo2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //GET : /
        public async Task<IActionResult> Index(string id)
        {
            Current currentWeather = new Current("4a1d40cc5c1c8b127cb5e2427dd5efda");
            WeatherDayInfo data = currentWeather.GetWeatherDataByCityName("Logroño").Result.WeatherDayInfo;
            ViewData["Latitud"] = currentWeather.GetWeatherDataByCityName("Logroño").Result.Coordinates.Latitude.ToString();
            ViewData["Longitud"] = currentWeather.GetWeatherDataByCityName("Logroño").Result.Coordinates.Longitude.ToString();
            ViewData["TemperaturaMaxima"] = data.MaximumTemperature.ToString();
            ViewData["TemperaturaMinima"] = data.MinimumTemperature.ToString();
            ViewData["TemperaturaActual"] = data.Temperature;
            return View();
        }

        //GET: /TemperaturaHoy
        public IActionResult TemperaturaHoy(string ciudad) 
        {
            try
            {
                if (!string.IsNullOrEmpty(ciudad)) 
                {
                    
                }
            }
            catch (Exception) 
            {
            
            }
            Console.WriteLine();
            return null;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}