using Web.Models;
using System.Collections.Generic;

namespace Web.Repositories.Interfaces
{
    public interface IPlanoRepository
    {
        IEnumerable<Plano> Planos { get; }
        IEnumerable<Plano> PlanosPreferidos { get; }
        Plano GetLancheById(int planoId);
    }
}
