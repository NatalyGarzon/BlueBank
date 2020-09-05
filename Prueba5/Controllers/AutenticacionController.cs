using BancoBll.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelo;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Prueba5.Controllers
{
  [Route("api")]
  [ApiController]

  public class AutenticacionController : ControllerBase
  {

    private readonly ICuentaBll _cuentaBll;


    private readonly UserManager<User> userManager;
    private readonly IConfiguration configuration;

    public AutenticacionController(UserManager<User> _userManager, IConfiguration _configuration, ICuentaBll cuentaBll)
    {
      userManager = _userManager;
      configuration = _configuration;
      _cuentaBll = cuentaBll;
    }

    [HttpPost("Autenticacion")]

    public async Task<IActionResult> Autenticacion([FromBody] Usuario usuario)
    {
      var UserResult = await userManager.FindByNameAsync(usuario.Nombre.Trim());

      if (!UserResult.LockoutEnabled)
      {
        return BadRequest(new { message = "User is inactive" });
      }

      var result = await userManager.CheckPasswordAsync(UserResult, usuario.Clave);

      if (!result)
        return BadRequest(new { message = "Username or password is incorrect" });
           

      return Ok(result);
    }
  }
}
