using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Parceiros")]
    public class Parceiro
    {
        public int ParceiroId { get; set; }
        [Display(Name = "Nome")]
        [Required]
        [StringLength(100)]
        public string ParceiroNome { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }
        public virtual List<Plano> Planos { get; set; }
    }
}
