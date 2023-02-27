using AgendaContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Usuário")]
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualização { get; set; }
        public PerfilEnum Perfil { get; set; }



    }
}
