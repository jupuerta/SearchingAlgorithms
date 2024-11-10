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

            int[,] matrix = CreateMatrixInitial(coloredSquares, n, m);

            return aAlgoritm.CaminoMasCorto(matrix, begin, end);
        }

        private int[,] CreateMatrixInitial(List<GridColoredSquare> coloredSquares, int n, int m)
        {
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int value = 0;
                    if (coloredSquares.Any(x => x.Detail.Equals("barrier") && x.X==i && x.Y==j))
                    {
                         value = 1;
                    }
                    matrix[i, j] = value;
                }
            }
            return matrix;
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
