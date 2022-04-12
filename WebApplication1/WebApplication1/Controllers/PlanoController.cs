using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
    public class PlanoController : Controller
    {
        private readonly IPlanorRepositorio _planoRepositorio;
        public PlanoController(IPlanorRepositorio planoRepositorio)
        {
            _planoRepositorio = planoRepositorio;
        }
        public IActionResult Index()
        {
            List<PlanoModel> planos = _planoRepositorio.ListarTodos();
            return View(planos);
        }
    }
}