using Microsoft.AspNetCore.Mvc;
using SearchingAlgorithms.ViewModels;
using System.Diagnostics;

namespace SearchingAlgorithms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(GridViewModel model)
        {
            model.n = 10;
            model.m = 22;
            return View(model);
        }

        public IActionResult DetalleGrid(GridViewModel model)
        {

            return View(model);
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
