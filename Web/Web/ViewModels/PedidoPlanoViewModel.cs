using Web.Models;
using System.Collections.Generic;

namespace LanchesMac.ViewModels
{
    public class PedidoPlanoViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
