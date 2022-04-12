using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<ParceiroModel> Parceiro { get; set; }
    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<PlanoModel> Plano { get; set; }


}
