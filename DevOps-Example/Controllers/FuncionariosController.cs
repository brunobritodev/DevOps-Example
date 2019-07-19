using DevOps.Domain;
using DevOps.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DevOps.Controllers
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
        public IActionResult Detalhes(int? id)
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

        public IActionResult Pagamento(int? id, int mes, int ano)
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

            var service = new FuncionarioFacade(funcionario);
            return View(service.CalcularPagamento(new DateTime(ano, mes, 1)));
        }


        public IActionResult FolhaPonto(int? id, int mes, int ano)
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

            var service = new FuncionarioFacade(funcionario);
            return View(service.ReportarHoras(new DateTime(ano, mes, 1)));
        }

    }
}
