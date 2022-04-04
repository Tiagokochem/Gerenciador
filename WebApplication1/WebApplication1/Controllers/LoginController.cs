using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
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
                    return RedirectToAction("Index", "Home");
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
