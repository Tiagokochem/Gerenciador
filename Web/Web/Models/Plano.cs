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

        [Required(ErrorMessage = "A descrição do plano deve ser informada")]
        [Display(Name = "Descrição do plano")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "O descrição detalhada do parceiro deve ser informada")]
        [Display(Name = "Descrição detalhada do plano")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada pode exceder {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

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

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsPlanoPreferido { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsPlanoAtivo { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public virtual Parceiro Parceiro { get; set; }
    }
}
