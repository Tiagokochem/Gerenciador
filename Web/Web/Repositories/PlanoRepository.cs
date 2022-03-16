using Web.Context;
using Web.Models;
using Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Web.Repositories
{
    public class PlanoRepository : IPlanoRepository
    {
        private readonly AppDbContext _context;

        public PlanoRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Plano> Planos => _context.Planos.Include(c => c.Parceiro);

        public IEnumerable<Plano> PlanosPreferidos => _context.Planos.Where(p => p.IsPlanoPreferido).Include(c => c.Parceiro);

        public Plano GetLancheById(int planoId) => _context.Planos.FirstOrDefault(l => l.PlanoId == planoId);
    }
}
