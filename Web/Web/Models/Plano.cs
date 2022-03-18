using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Planos")]
    public class Plano
    {
        public int PlanoId { get; set; }

        [Required(ErrorMessage="O nome do plano deve ser informado")]
        [Display(Name = "Nome do plano")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string PlanoNome { get; set; }

        [Required(ErrorMessage = "O resumo do plano deve ser informado")]
        [Display(Name = "Breve resumo do plano")]
        [MinLength(20, ErrorMessage = "Descrição resumida deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição resumida pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "Categoria deve ser informado")]
        [Display(Name = "Categoria")]
        [MinLength(20, ErrorMessage = "Descrição resumida deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição resumida pode exceder {1} caracteres")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "O termo do plano deve ser informado")]
        [Display(Name = "Termo de uso do plano")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(5000, ErrorMessage = "Descrição detalhada pode exceder {1} caracteres")]
        public string TermoPlano { get; set; }

        [Required(ErrorMessage="Informe o preço do produto")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 99.99,ErrorMessage ="O preço deve estar entre 1 e 99,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Desconto")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 99.99, ErrorMessage = "O desconto deve estar entre 1 e 99,99")]
        public decimal Desconto { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }


        [Display(Name = "Preferido?")]
        public bool IsPlanoPreferido { get; set; }

        [Display(Name = "Ativo?")]
        public bool IsPlanoAtivo { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public virtual Parceiro Parceiro { get; set; }
    }
}
