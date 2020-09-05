using BancoDal.Configuracion;
using BancoDal.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BancoDal
{
    public class BancoContext : IdentityDbContext<User, Roles, Guid>, IBancoContext
    {
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }


    public BancoContext(DbContextOptions<BancoContext> options)
            : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);           

        builder.ApplyConfiguration(new CuentaConf());

        builder.ApplyConfiguration(new PersonaConf());
    }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
