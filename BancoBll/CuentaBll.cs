using BancoBll.Interfaces;
using BancoDal.Interfaces;
using Modelo;
using System;

namespace BancoBll
{
    public class CuentaBll : ICuentaBll
    {
        private readonly ICuentaDal cuentaDal;


        public CuentaBll(ICuentaDal _cuentaDal)
        {
            this.cuentaDal = _cuentaDal;
        }


        public void ConsignarCuenta(int cuenta, int valor)
        {
            cuentaDal.ConsignarDinero(cuenta, valor);
        }

        public CuentaDatos CosultarCuenta(int numerocuenta)
        {
            return cuentaDal.ConsultarCuenta(numerocuenta);
        }


        public void CrearCuenta(int numeroCuenta, int valorInicial, int Idpersona)
        {
            cuentaDal.GuardarCuenta(numeroCuenta, valorInicial, Idpersona);
        }

        public void RetirarCuenta(int cuenta, int valor)
        {
            cuentaDal.RetirarDinero(cuenta, valor);
        }
    }
}
