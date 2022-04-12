using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Enums;


namespace WebApplication1.Models;

public class PlanoModel
{
    public int PlanoId { get; set; }
    [Display(Name = "Nome do plano")]
    [Required]
    [StringLength(100)]
    public string NomePlano { get; set; }

    [Required(ErrorMessage = "O Termo deve ser informada")]
    [Display(Name = "Termo")]
    [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
    [MaxLength(2000, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
    public string TermoDeUso { get; set; }

    [Required(ErrorMessage = "Informe o preço do plano")]
    [Display(Name = "Preço")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
    public decimal PrecoPlano { get; set; }

    public int tipoPlano { get; set; }

    [Required(ErrorMessage = "Informe o perfil do  usuário")]
    public PlanoEnum? PlanoContratado { get; set; }

   // public virtual List<ParceiroModel>

}
