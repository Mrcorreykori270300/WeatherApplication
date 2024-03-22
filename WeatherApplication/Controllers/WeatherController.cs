using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherApplication.Models;

namespace WeatherApplication.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public WeatherController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Mumbai";
            }

            var client = _clientFactory.CreateClient(name);
            var apiKey = "d734c9c8448ae9e75f1149f3329cbc70";
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={name}&appid={apiKey}&units=metric";

            var response = await client.GetAsync(url);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();
                    if (weatherData != null)
                    {
                        return View(weatherData);
                    }
                    else
                    {
                        // Handle case where content couldn't be read properly
                        TempData["ErrorMessage"] = "Failed to retrieve weather data. Please try again later.";
                        return RedirectToAction("Index");
                    }
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Handle case where location is not found
                    TempData["ErrorMessage"] = "Location not found. Please enter a valid location.";
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle other error status codes
                    return View("Error");
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                TempData["ErrorMessage"] = "Failed to retrieve weather data. Please try again later.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Handle other unexpected errors
                TempData["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
                return RedirectToAction("Index");
            }
        }


    }
}

