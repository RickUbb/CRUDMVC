using CRUDMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Cada formulario creado tambien se creara en la carpeta Views
        public IActionResult Index() //retorna formulario HTML
        {
            return View();
        }

        public IActionResult Privacy() //retorna formulario HTML
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