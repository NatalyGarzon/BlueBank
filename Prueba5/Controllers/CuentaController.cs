
using BancoBll.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace Prueba5.Controllers
{
  [Route("api")]
  [ApiController]
  public class CuentaController : ControllerBase
  {
    private readonly ICuentaBll _cuentaBll;

    private Cuenta cuenta = new Cuenta();


    public CuentaController(ICuentaBll cuentaBll)
    {
      _cuentaBll = cuentaBll;
    }

    [Route("Agregar")]
    [HttpPost]
    [AllowAnonymous]

    public IActionResult AgregarCuenta([FromBody] CuentaMap datosCuenta)
    {
      _cuentaBll.CrearCuenta(datosCuenta.NumeroCuenta, datosCuenta.NuevoSaldo, datosCuenta.IdPersona );
      return Ok(datosCuenta.NumeroCuenta);
    }

    [Route("Consultar")]
    [HttpGet]
    [AllowAnonymous]
    public IActionResult ConsultarCuenta(int numeroCuenta)
    {
      return Ok(_cuentaBll.CosultarCuenta(numeroCuenta));


    }


    [Route("Consignar")]
    [HttpPost]
    [AllowAnonymous]

    public IActionResult ConsignarCuenta([FromBody] CuentaMoviemientos cuentaMovimientos)
    {
      _cuentaBll.ConsignarCuenta(cuentaMovimientos.NumeroCuenta, cuentaMovimientos.Valor);
      return Ok(cuentaMovimientos.NumeroCuenta);
    }

    [Route("Retirar")]
    [HttpPost]
    [AllowAnonymous]

    public IActionResult RetirarCuenta([FromBody] CuentaMoviemientos cuentaMovimientos)
    {
      _cuentaBll.RetirarCuenta(cuentaMovimientos.NumeroCuenta, cuentaMovimientos.Valor);
      return Ok(cuentaMovimientos.NumeroCuenta);
    }

  }
}
