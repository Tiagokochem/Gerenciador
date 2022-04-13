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

        public IEnumerable<ParceiroModel> Parceiros => _context.Parceiros;
    }

    
}
