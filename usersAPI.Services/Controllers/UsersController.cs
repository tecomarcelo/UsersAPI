using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Interfaces.Application;

namespace UsersAPI.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService? _userAppService;

        public UsersController(IUserAppService? userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// Criar conta de usuário
        /// </summary>
        // [AllowAnonymous] permite uso sem a autenticação
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add([FromBody] UserAddRequestDto dto)
        {
            return StatusCode(201, _userAppService?.Add(dto));
        }

        /// <summary>
        /// Alterar os dados da conta do usuário
        /// </summary>
        // verbo [HttpPath] diferente do put não tem obrigação de alterar todos os campos.
        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        /// <summary>
        /// Excluir conta de usuário
        /// </summary>
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();    
        }

        /// <summary>
        /// Consultar os dados da conta do usuário
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
