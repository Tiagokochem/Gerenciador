using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("CarrinhoCompraItens")]
    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemId { get; set; }
        public Plano Plano { get; set; }
        public int Quantidade { get; set; }

        [StringLength(100)]
        public string CarrinhoCompraId { get; set; }
    }
}
