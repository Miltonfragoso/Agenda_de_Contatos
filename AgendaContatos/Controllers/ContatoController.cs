using AgendaContatos.Models;
using AgendaContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgendaContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            this.contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = contatoRepositorio.BuscarTodos();
            return View(contatos);
        }



        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado comsucesso!";
                    return RedirectToAction("Index");
                }


                return View(contato);
            }

            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu Contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            ContatoModel contato = contatoRepositorio.ListarPorId(id);
            return View(contato);
        }


        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contatoRepositorio.Atualizar(contato);

                    TempData["MensagemSucesso"] = "Contato alterado com comsucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu Contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }


        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = contatoRepositorio.ListarPorId(id);
            return View(contato);

        }

        public IActionResult Apagar(int id)
        {
            try
            {
               bool apagado = contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com comsucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato!";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu Contato, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
