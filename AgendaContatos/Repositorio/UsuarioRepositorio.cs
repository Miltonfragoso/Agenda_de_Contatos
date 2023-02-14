using AgendaContatos.Data;
using AgendaContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            this.bancoContext = bancoContext;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //  Gravar no banco 
            usuario.DataCadastro = DateTime.Now;
            bancoContext.Usuarios.Add(usuario);
            bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve  um erro na atualização do usuário ");

            usuarioDB.Nome    = usuario.Nome;
            usuarioDB.Login    = usuario.Login;
            usuarioDB.Email   = usuario.Email;
            usuarioDB.Perfil   = usuario.Perfil;
            usuarioDB.DataAtualização   = DateTime.Now;
            bancoContext.Usuarios.Update(usuarioDB);
            bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve  um erro na deleção do usuário ");
            bancoContext.Usuarios.Remove(usuarioDB);
            bancoContext.SaveChanges();

            return true;
        }
    }
}
