using AgendaContatos.Models;
using AgendaContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgendaContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> Usuarios = usuarioRepositorio.BuscarTodos();
            return View(Usuarios);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado comsucesso!";
                    return RedirectToAction("Index");
                }


                return View(usuario);
            }

            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu Usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }


        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = usuarioRepositorio.ListarPorId(id);
            return View(usuario);

        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = usuarioRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com comsucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu Usuário!";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu Usuário, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

    }
}
