using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BancoDal.Interfaces
{
    public interface IBancoContext 
    {
        DbSet<Persona> Persona { get; set; }
        DbSet<Cuenta> Cuenta { get; set; }

        int SaveChanges();
    }
}
