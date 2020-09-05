using BancoDal.Interfaces;
using Microsoft.AspNetCore.Identity;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDal.DatosIniciales
{
    public class CrearUsuario
    {
        private IPersonaDal personaDal;


        public CrearUsuario()
        {           
        }
             
        public void  CrearPersona(IBancoContext _context)
        {
            IPersonaDal persponaDal = new PersonaDal(_context);
            persponaDal.GuardarPersona("123456", "Nataly Garzon");

        }


    }
}
