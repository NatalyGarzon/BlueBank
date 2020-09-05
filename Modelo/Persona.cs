using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Persona
    {
        public int IdPersona { get; set; }

        public string Nombre { get; set; }

        public string Documento { get; set; }

        public ICollection<Cuenta> cuentas { get; set; }

    }
}
