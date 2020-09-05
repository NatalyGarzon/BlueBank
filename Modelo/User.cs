using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Modelo
{
    public class User : IdentityUser<Guid>
    {

        public int Nombre { get; set; }
        public int Apellido { get; set; }
    }
}
