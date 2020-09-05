using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDal.Configuracion
{
    public class CuentaConf : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("Cuenta", "DBO").HasKey(x=> x.IdCuenta);

        }
    }
}
