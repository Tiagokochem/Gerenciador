using Microsoft.AspNetCore.Mvc;
using WebApplication2.Repositorio;

namespace WebApplication2.Controllers
{
    public class ParceiroController : Controller
    {
        private readonly IParceiroRepositorio _parceiroRepositorio;

        public ParceiroController(IParceiroRepositorio parceiroRepositorio)
        {
            _parceiroRepositorio = parceiroRepositorio;
        }

        public IActionResult Listar()
        {
            var parceiros = _parceiroRepositorio.Parceiros;
            return View(parceiros);
        }
    }
}
