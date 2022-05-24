using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class PlanoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o plano")]
        public string Plano { get; set; }

        [Required(ErrorMessage = "Digite o valor")]
        public float Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public int UsuarioId { get; set; }


        public virtual List<UsuarioModel> Usuarios { get; set; }

    }
}
