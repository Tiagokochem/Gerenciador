using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]

        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]

        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email do usuário")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o perfil do  usuário")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
