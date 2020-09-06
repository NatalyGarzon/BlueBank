using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoBll.Interfaces
{
    public interface ICuentaBll
    {
        void CrearCuenta(int numeroCuenta, int valorInicial, int IdPersona);
        void ConsignarCuenta(int cuenta, int valor);
        void RetirarCuenta(int cuenta, int valor);
        CuentaDatos CosultarCuenta(int numerocuenta);


    }
}
