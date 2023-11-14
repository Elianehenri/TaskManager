using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Dtos;
using TaskManager.Interfaces.Services;

namespace TaskManager.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        // Injeção de dependência do IUserService
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public ActionResult Post([FromBody] UserRegisterDto userRegisterDto)
        {
            try
            {
                _userService.AddUser(userRegisterDto);
                return Ok(new { message = "Usuário cadastrado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                if (loginRequestDto == null)
                {
                      return BadRequest(new { message = "Dados de login inválidos" });
                }
                var loginResponseDto = _userService.Login(loginRequestDto);
                return Ok(loginResponseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
        }
    }
}
