using Web.Models;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Plano> PlanosPreferidos { get; set; }
    }
}
