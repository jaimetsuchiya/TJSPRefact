using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDAU.Common;
using TJSPApi.DTOs;
using System.IdentityModel.Tokens.Jwt;
using SGDAU.Seguranca.Domain;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace TJSPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISegurancaService segurancaService;
        private readonly IConfiguration configurationService;

        public SecurityController(IConfiguration configurationService, ISegurancaService segurancaService)
        {
            this.segurancaService = segurancaService;
            this.configurationService = configurationService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] Authenticate.Request dto)
        {
            //Valida o Client informado
            if (!this.configurationService.GetSection("Authentication:Clients").Get<string[]>().Contains(dto.ClientId))
                return new UnauthorizedResult();

            var authenticationResult = this.segurancaService.Authenticate(dto);
            if (authenticationResult == null)
                return BadRequest();

            return Ok(authenticationResult);
        }

        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword dto)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPassword dto)
        {
            throw new NotImplementedException();
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> CurrentUser()
        {
            var user = HttpContext.User.Claims.Select(x => x.Value);
            return Ok(user);
        }
    }
}