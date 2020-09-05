using BancoDal.Interfaces;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Linq;

namespace BancoDal
{
  public class CuentasDal : ICuentaDal
  {
    Cuenta cuenta;

    private readonly IBancoContext context;

    public CuentasDal(IBancoContext context)
    {
      this.context = context;
    }

    public void GuardarCuenta(int numeroCuenta, int valorInicial, int persona)
    {
      cuenta = new Cuenta
      {
        NumeroCuenta = numeroCuenta,
        IdPersona = context.Persona.Find(persona),
        Saldo = valorInicial
      };

      context.Cuenta.Add(cuenta);
      context.SaveChanges();

    }


    public CuentaDatos ConsultarCuenta(int numeroCuenta)
    {
      cuenta = new Cuenta();

      //cuenta = context.Cuenta.Include("IdPersona").Where(x => x.NumeroCuenta == numeroCuenta).FirstOrDefault();

      var pp = (from p in context.Cuenta
                join h in context.Persona
                on p.IdPersona.IdPersona equals h.IdPersona
                select new CuentaDatos
                {
                 
                  NumeroCuenta = p.NumeroCuenta,
                  Saldo = p.Saldo,
                  NombrePersona = h.Nombre
                }).FirstOrDefault();
      return pp;
    }

    public void ConsignarDinero(int numeroCuenta, int valor)
    {
      cuenta = new Cuenta();

      cuenta = context.Cuenta.Where(x => x.NumeroCuenta == numeroCuenta).FirstOrDefault();

      cuenta.Saldo = cuenta.Saldo + valor;

      context.SaveChanges();

    }

    public void RetirarDinero(int numeroCuenta, int valorRetiro)
    {
      cuenta = new Cuenta();

      cuenta = context.Cuenta.Where(x => x.NumeroCuenta == numeroCuenta).FirstOrDefault();

      if (cuenta.Saldo >= valorRetiro)
      {
        cuenta.Saldo = cuenta.Saldo - valorRetiro;
      }

      context.SaveChanges();
    }
  }
}
