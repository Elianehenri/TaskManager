using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Dtos;
using TaskManager.Interfaces.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;   

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [Route("userId")]
        public ActionResult Get(int userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter usuário");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
       // [Authorize]
        public ActionResult Delete(int userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return Ok( "Usuário deletado com sucesso" );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar usuário");
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPut]
        [Authorize]
        // [Route("userId")]
        public IActionResult Put( UserRequestDto userRequestDto)
        {
           

            // Obtenha o ID do usuário autenticado.
            var idUser = GetAuthenticatedUserId();

            try
            {
                _userService.UpdateUser(userRequestDto,idUser);
                return Ok("Usuário atualizado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar usuário");
                return BadRequest(new { message = ex.Message });
            }

        }


        private int? GetAuthenticatedUserId()
        {
            var idUser = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return idUser != null ? int.Parse(idUser) : (int?)null;
        }

    }
}
