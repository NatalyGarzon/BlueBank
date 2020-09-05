using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDal.Configuracion
{
  public class PersonaConf : IEntityTypeConfiguration<Persona>
  {
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
      builder.ToTable("Persona", "DBO").HasKey(x => x.IdPersona);

      builder.HasMany(x => x.cuentas).WithOne(j => j.IdPersona);
    }
  }
}
