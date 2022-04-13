using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Context;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<PlanoModel> Planos { get; set; }

    public DbSet<ParceiroModel> Parceiros { get; set; }

}
