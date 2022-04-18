using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.Repositorio.Interfaces;


namespace WebApplication2.Repositorio
{
    public class ParceiroRepositorio : IParceiroRepositorio
    {
        private readonly AppDbContext _context;

        public ParceiroRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ParceiroModel> Parceiros => _context.Parceiros.Include(c=> c.Planos);

        public IEnumerable<ParceiroModel> ParceiroAtivo => _context.Parceiros.
                                            Where(p => p.ParceiroAtivo)
                                            .Include(a => a.Planos);

        public ParceiroModel GetParceiroById(int parceiroId)
        {
            return _context.Parceiros.FirstOrDefault(p => p.ParceiroId == parceiroId);
        }
    }

    
}
