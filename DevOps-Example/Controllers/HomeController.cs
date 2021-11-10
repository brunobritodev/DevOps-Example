using DevOps.Models;
using DevOps.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace DevOps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ImagemEventoModel _settings;

        public HomeController(IOptions<ImagemEventoModel> settings)
        {
            _settings = settings.Value;
            Repository = Repositorio.CriarRepositorio();
        }

        public static Repositorio Repository { get; set; }

        public IActionResult Index()
        {
            return View(_settings);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GerarMassa()
        {
            Repository = Repositorio.CriarRepositorio();
            return RedirectToAction("Index", "Funcionarios");
        }
    }
}
