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

        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Digite o e-mail docontato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a senha do Usuário")]
        public string Senha { get; set; }


        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualização { get; set; }
        public PerfilEnum Perfil { get; set; }



    }
}
