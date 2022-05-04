﻿using Microsoft.EntityFrameworkCore;
using Site.Models;

namespace Site.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base()
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}