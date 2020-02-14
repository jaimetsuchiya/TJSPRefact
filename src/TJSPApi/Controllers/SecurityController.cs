using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGDAU.Common;
using TJSPApi.DTOs;

namespace TJSPApi.Controllers
{
    [Route("security")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] Authenticate dto)
        {
            throw new NotImplementedException();
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
    }
}