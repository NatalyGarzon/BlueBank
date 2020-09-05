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
using System.Web.Http.Description;

namespace Prueba5.Controllers
{
  [ApiController]
  [Route("PersonaApi")]
  public class PersonaController : ControllerBase
  {
    private readonly IPersonaBll personaBll;

    public PersonaController(IPersonaBll _personaBll)
    {
      personaBll = _personaBll;
    }

    [Route("Consultar")]
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Persona>>> ListaPersonas()
    {
      var pp = personaBll.TraerPersonas();
      return Ok(pp);
    }
    
  }
}
