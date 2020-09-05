using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDal.Interfaces
{
    public interface ICuentaDal
    {
        void GuardarCuenta(int numeroCuenta, int valorInicial, int IdPersona);

        void RetirarDinero(int numeroCuenta, int valorRetiro);

    CuentaDatos ConsultarCuenta(int numeroCuenta);

        void ConsignarDinero(int numeroCuenta, int valor);

        


    }
}
