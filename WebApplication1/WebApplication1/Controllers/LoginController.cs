using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    TempData["MensagemErro"] = $"Senha do usuario é invalido, tente novamente.";

                    {
                        TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s). Por favor, tente novamente.";

                    }
                }
                return View("Index");
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos realizar seu login!{erro.Message}"; 
                return RedirectToAction("Index");
            }
        }
    }
}
