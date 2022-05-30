using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Models
{
    public class PlanoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o plano")]
        public string Plano { get; set; }

        [Required(ErrorMessage = "Digite o valor")]
        public float Valor { get; set; }

        [ForeignKey("UsuarioModel")]
        public int UsuarioModelId { get; set; }

        public UsuarioModel Usuario { get; set;  }

    }
}
