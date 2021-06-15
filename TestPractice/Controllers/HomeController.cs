using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TestPractice.Models;

namespace TestPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
        public async Task<IActionResult> Get()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await  client.GetAsync("http://api.openweathermap.org/data/2.5/group?id=1580578,1581129,1581297,1581188,1587923&units=metric&appid=91b7466cc755db1a94caf6d86a9c788a");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Rootobject>(responseBody);
                var weather = new newWeather();
                List<newWeather.desciption> desciptions = new List<newWeather.desciption>();
                foreach (var item in result.list)
                {
                    newWeather.desciption desciption = new newWeather.desciption();
                    desciption.cityId = result.list.Select(p => p.id).FirstOrDefault();
                    desciption.cityName = result.list.Select(p => p.name).FirstOrDefault();
                    desciption.weatherDescription = result.list.Select(p => p.weather.Select(p => p.description).FirstOrDefault()).FirstOrDefault();
                    desciption.weatherMain = item.weather.Select(p => p.main).FirstOrDefault();
                    desciption.weatherIcon = string.Format("http://openweathermap.org/img/wn/{0}/@2x.png", item.weather.Select(p => p.icon).FirstOrDefault());
                    desciption.mainTemp = item.main.temp;
                    desciption.mainHumidity = item.main.humidity;
                    desciptions.Add(desciption);
                }
                return Json(new
                {
                    data = desciptions,
                    message= "Current weather information of cities",
                    statuscode = 200
                });
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
