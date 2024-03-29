﻿using CovidWebService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CovidWebService.Controllers
{

    /// <summary>
    /// Preparar geração de JWT Token
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IJWTAuthManager jWTAuthManager;

        public SecurityController(IJWTAuthManager jWTAuthManager)
        {
            this.jWTAuthManager = jWTAuthManager;

        }

        /// <summary>
        /// Método POST para Autenticação...sem autenticação!!!
        /// </summary>
        /// <param name="loginDetalhes"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public AuthResponse Login(AuthRequest loginDetalhes) //or ([FromBody] AuthRequest loginDetalhes)
        {
            AuthResponse token = jWTAuthManager.Authenticate(loginDetalhes);    //sem Claims

            if (token == null)
            {
                token.Token = Unauthorized().ToString();
            }

            return token;

            /*
             * Se retorno for IActionResult:
             *
             * if (token == null)
             *       return Unauthorized();
             *  return Ok(token);
             */
        }
    }
}
