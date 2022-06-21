using Microsoft.EntityFrameworkCore;
using Site.Models;

namespace Site.Data
{
    public class BancoContent : DbContext
    {
        public BancoContent(DbContextOptions<BancoContent> options) :
            base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<PlanoModel> Planos { get; set; }

    }
}
