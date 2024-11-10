using Microsoft.AspNetCore.Mvc;
using SearchingAlgorithms.Models;
using SearchingAlgorithms.Models.Entities;
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
            model.n = Grid.n;
            model.m = Grid.m;

            return View(model);
        }

        [HttpPost]
        [Route("DetallePathFollow")]
        public NodeProcessedViewModel DetallePathFollow([FromBody] List<GridColoredSquare> coloredSquares)
        {
            int n = Grid.n; 
            int m = Grid.m;
            AAlgoritm aAlgoritm = new AAlgoritm();

            var begin = coloredSquares.Where(x => x.Detail.Equals("begin")).Select(z=> (z.X, z.Y)).FirstOrDefault();
            var end = coloredSquares.Where(x => x.Detail.Equals("end")).Select(z => (z.X, z.Y)).FirstOrDefault();

            int[,] matrix = new int[n, m];

            // Inicializar la matriz con valores
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = 0; // Puedes cambiar este valor a lo que necesites
                }
            }
            return aAlgoritm.CaminoMasCorto(matrix, begin, end);
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
