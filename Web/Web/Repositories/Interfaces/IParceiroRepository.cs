using Web.Models;
using System.Collections.Generic;

namespace Web.Repositories.Interfaces
{
    public interface IParceiroRepository
    {
        IEnumerable<Parceiro> Parceiros { get; }

        Parceiro GetLancheById(int parceiroId);

    }
}
