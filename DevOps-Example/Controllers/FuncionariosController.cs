using DevOps.Controllers;
using DevOps.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DevOps_Example.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly Repositorio _context;

        public FuncionariosController()
        {
            _context = HomeController.Repository;
        }

        // GET: Funcionarios
        public IActionResult Index()
        {
            return View(_context.Funcionarios);
        }

        // GET: Funcionarios/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = _context.Funcionarios.FirstOrDefault(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

    }
}
