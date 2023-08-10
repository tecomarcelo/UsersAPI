using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace usersAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Criar conta de usuário
        /// </summary>
        [HttpPost]
        public IActionResult Add()
        {
            return Ok();
        }
        /// <summary>
        /// Alterar os dados da conta do usuário
        /// </summary>
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
