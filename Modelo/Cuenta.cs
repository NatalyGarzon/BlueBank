using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Cuenta
    {
        public int IdCuenta { get; set; }
        public int NumeroCuenta { get; set; }
        public int Saldo { get; set; }
        public Persona IdPersona { get; set; }

    }
}
