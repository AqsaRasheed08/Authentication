using System.Diagnostics;
using Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using GoogleAuthentication.Services;


namespace Authentication.Controllers
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
            var clientId = "625335937695-epb98brb8er4teiqvh51u2fiahie07ic.apps.googleusercontent.com";
            var url = "https://localhost:7158/login/GoogleLoginCallback";
            var response = GoogleAuth.GetAuthUrl(clientId, url);
            ViewBag.response = response;
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
    }
}