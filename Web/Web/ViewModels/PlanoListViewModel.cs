using Web.Models;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class PlanoListViewModel
    {
        public IEnumerable<Plano> Planos { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
