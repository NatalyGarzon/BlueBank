using BancoDal.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancoDal
{
    public class PersonaDal : IPersonaDal
    {
        Persona persona;

        private readonly IBancoContext context;

        public PersonaDal(IBancoContext _context)
        {
            context = _context;
        }

        public void GuardarPersona(string documento, string nombre)
        {
            persona = new Persona
            {
                Nombre = nombre,
                Documento = documento
            };

            if (!context.Persona.Any())
            {
                context.Persona.Add(persona);
                context.SaveChanges();
            }

        }

        public List<Persona> TraerPersonas()
        {
            return context.Persona.ToList();
        }
    }
}
