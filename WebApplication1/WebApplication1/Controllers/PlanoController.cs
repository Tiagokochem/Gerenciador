using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
    public class PlanoController : Controller
    {
        private readonly IListarRepositorio _listarRepositorio;
        public PlanoController(IListarRepositorio listarRepositorio)
        {
            _listarRepositorio = listarRepositorio;
        }
        public IActionResult Index()
        {
            List<PlanoModel> planos = _listarRepositorio.ListarTodos();
            return View(parceiros);
        }
    }
}