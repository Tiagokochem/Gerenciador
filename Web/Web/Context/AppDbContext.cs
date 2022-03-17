using Web.Models;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web.Context
{
    public class AppDbContext : DbContext //IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<Plano> Planos { get; set; }


        //public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        //public DbSet<Pedido> Pedidos { get; set; }
       // public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
