using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.ListarTodos();
            return View(usuarios);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);
                    TempData["MesagemSucesso"] = "Usuario Cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MesagemErro"] = $"Ops, não foi possível cadastrar seu usuario, tente novamente, problema: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
