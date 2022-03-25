using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
    public class ListarController : Controller
    {
        private readonly IListarRepositorio _listarRepositorio;
        public ListarController(IListarRepositorio listarRepositorio)
        {
            _listarRepositorio = listarRepositorio;
        }
        public IActionResult Index()
        {
            List<ParceiroModel> parceiros = _listarRepositorio.ListarTodos();
            return View(parceiros);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            ParceiroModel parceiro = _listarRepositorio.ListarPorId(Id);
            return View(parceiro);
        }

        public IActionResult ApagarConfirmacao(int Id)
        {
            ParceiroModel parceiro = _listarRepositorio.ListarPorId(Id);
            return View();
        }

        public IActionResult Apagar(int id)
        {
            _listarRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cadastrar(ParceiroModel parceiro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _listarRepositorio.Adicionar(parceiro);
                    TempData["MesagemSucesso"] = "Contato Cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(parceiro);
            }
            catch (System.Exception erro)
            {
                TempData["MesagemErro"] = $"Ops, não foi possível cadastrar seu contato, tente novamente, problema: {erro.Message}";
                return RedirectToAction("Index"); ;
            }
        }
        [HttpPost]
        public IActionResult Alterar(ParceiroModel parceiro)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _listarRepositorio.Atualizar(parceiro);
                    return RedirectToAction("Index");
                }
                return View("Editar", parceiro);
            }
            catch (System.Exception erro)
            {

                TempData["MesagemErro"] = $"Ops, não foi possível cadastrar seu contato, tente novamente, problema: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
