using BancoBll.Interfaces;
using BancoDal.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoBll
{
    public class PersonaBll : IPersonaBll
    {
        private readonly IPersonaDal personaDal;

        public PersonaBll(IPersonaDal _personaDal)
        {
            personaDal = _personaDal;
        }
        public List<Persona> TraerPersonas()
        {
            return personaDal.TraerPersonas();
        }
    }
}
