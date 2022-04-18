using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

[Table("Parceiros")]

public class ParceiroModel
{
    [Key]
    public int ParceiroId { get; set; }

    [Display(Name = "Nome")]
    [Required]
    [StringLength(100)]
    public string ParceiroNome { get; set; }

    [Required(ErrorMessage = "A fantasia deve ser informada")]
    [Display(Name = "Fantasia")]
    [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
    public string ParceiroFantasia { get; set; }

    [Required(ErrorMessage = "A Razão Social deve ser informada")]
    [Display(Name = "Razão Social")]
    [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
    public string ParceiroRazaoSocial { get; set; }

    [Required(ErrorMessage = "Informe o seu CEP")]
    [Display(Name = "CEP")]
    [StringLength(10, MinimumLength = 8)]
    public string ParceiroCep { get; set; }

    [StringLength(50)]
    public string ParceiroCidade { get; set; }

    [StringLength(10)]
    public string ParceiroEstado { get; set; }

    [Required(ErrorMessage = "Informe o seu telefone")]
    [StringLength(25)]
    [DataType(DataType.PhoneNumber)]
    public string ParceiroTelefone { get; set; }

    [Required(ErrorMessage = "Informe o email.")]
    [StringLength(50)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
      ErrorMessage = "O email não possui um formato correto")]
    public string ParceiroEmail { get; set; }

    [Display(Name = "Data do cadastro")]
    [DataType(DataType.Text)]
    [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
    public DateTime DataDeCadastro { get; set; } = DateTime.Now;

    [Display(Name = "Data de Alteração")]
    [DataType(DataType.Text)]
    [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
    public DateTime? DataDeAlteracao { get; set; } = DateTime.Now;

    public bool ParceiroAtivo { get; set; }

    public virtual List<PlanoModel> Planos { get; set; }

}
