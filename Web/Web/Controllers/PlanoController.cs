using Web.Models;
using Web.Repositories.Interfaces;
using Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Web.Controllers
{
    public class PlanoController : Controller
    {
        private IParceiroRepository _parceiroRepository { get; }
        private readonly IPlanoRepository _planoRepository;

        public PlanoController(IParceiroRepository parceiroRepository,
            IPlanoRepository planoRepository)
        {
            _parceiroRepository = parceiroRepository;
            _planoRepository = planoRepository;
        }

        public IActionResult List(string parceiro)
        {
            //string _categoria = categoria;
            IEnumerable<Plano> planos;
            string planoAtual = string.Empty;

            if (string.IsNullOrEmpty(parceiro))
            {
                planos = _planosRepository.Planos.OrderBy(p => p.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                //este codigo foi alterado por macoratti
                ///////////////////////////////////////////////////////////////////////////////////
                //if (string.Equals("Normal", _categoria, StringComparison.OrdinalIgnoreCase))
                //    lanches = _lancheRepository.Lanches.Where(p => p.Categoria.CategoriaNome.Equals("Normal")).OrderBy(p => p.Nome);
                //else
                //    lanches = _lancheRepository.Lanches.Where(p => p.Categoria.CategoriaNome.Equals("Natural")).OrderBy(p => p.Nome);
                ////////////////////////////////////////////////////////////////////////////////////

                lanches = _lancheRepository.Lanches
                           .Where(p => p.Categoria.CategoriaNome.Equals(categoria))
                           .OrderBy(p => p.Nome);

                categoriaAtual = categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lancheListViewModel);
        }
        public ViewResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(d => d.LancheId == lancheId);
            if (lanche == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(lanche);
        }
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Lanche> lanches;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(p => p.Nome.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = "Todos os lanches"
            });
        }

    }
}