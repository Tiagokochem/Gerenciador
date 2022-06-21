using Site.Filters;
using Site.Models;
using Site.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Site.Controllers
{
    //[PaginaParaUsuarioLogado]
    public class PlanoController : Controller
    {
        private readonly IPlanoRepositorio _planoRepositorio;

        public PlanoController(IPlanoRepositorio planoRepositorio)
        {
            _planoRepositorio = planoRepositorio;
        }

        public IActionResult Index()
        {
            List<PlanoModel> planos = _planoRepositorio.BuscarTodos();

            return  View(planos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            PlanoModel plano = _planoRepositorio.BuscarPorID(id);
            return View(plano);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            PlanoModel plano = _planoRepositorio.BuscarPorID(id);
            return View(plano);
        }
        public IActionResult Apagar(int id)
            {
                try
                {
                    bool apagado = _planoRepositorio.Apagar(id);

                    if (apagado) TempData["MensagemSucesso"] = "Contato apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu contato, tente novamante!";
                    return RedirectToAction("Index");
                }
                catch (Exception erro)
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                    return RedirectToAction("Index");
                }
            }

            [HttpPost]
            public IActionResult Criar(PlanoModel planos)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                    planos = _planoRepositorio.Adicionar(planos);

                        TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                        return RedirectToAction("Index");
                    }

                    return View(planos);
                }
                catch (Exception erro)
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                    return RedirectToAction("Index");
                }
            }

            [HttpPost]
            public IActionResult Editar(PlanoModel planos)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        planos = _planoRepositorio.Atualizar(planos);
                        TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                        return RedirectToAction("Index");
                    }

                    return View(planos);
                }
                catch (Exception erro)
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                    return RedirectToAction("Index");
                }
            }
        }
    } 
