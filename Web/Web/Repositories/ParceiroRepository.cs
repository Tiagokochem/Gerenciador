using Web.Context;
using Web.Models;
using Web.Repositories.Interfaces;
using System.Collections.Generic;

namespace Web.Repositories
{
    public class ParceiroRepository : IParceiroRepository
    {
        private readonly AppDbContext _context;

        public ParceiroRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Parceiro> Parceiros => _context.Parceiros;

        public Parceiro GetLancheById(int parceiroId) =>
      _context.Parceiros.FirstOrDefault(l => l.ParceiroId == parceiroId);
    }

    
}
