using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDal.Interfaces
{
    public interface IPersonaDal
    {
        List<Persona> TraerPersonas();

        void GuardarPersona(string documento, string nombre);
    }
}
