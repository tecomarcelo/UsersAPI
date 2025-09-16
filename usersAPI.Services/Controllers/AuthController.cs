using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;

namespace UsersAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService? _authAppService;

        public AuthController(IAuthAppService? authAppService)
        {
            _authAppService = authAppService;
        }

        /// <summary>
        /// Autenticar o usuário
        /// </summary>
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponseDto), 200)]
        public IActionResult Login(LoginRequestDto dto)
        {
            return StatusCode(200, _authAppService?.Login(dto));
        }

        /// <summary>
        /// Recuperar senha de acesso do usuário
        /// </summary>
        [Route("forgot-password")]
        [HttpPost]
        public IActionResult ForgotPassword()
        {
            return Ok();
        }

        /// <summary>
        /// Reiniciar senha de acesso do usuário
        /// </summary>
        [Authorize]
        [Route("reset-password")]
        [HttpPost]
        public IActionResult ResetPassword()
        {
            return Ok();
        }
    }
}
