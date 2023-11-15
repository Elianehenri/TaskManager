using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Dtos;
using TaskManager.Interfaces.Services;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskManagerController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<UserController> _logger;

        public TaskManagerController(ITaskService taskService, ILogger<UserController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        //obtem as taks por id de user
        public IActionResult GetAll(int userId)
        {
            try
            {
                List<Tasks> tasks = _taskService.GetAll(userId);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todas as tarefas");
                return StatusCode(500, "Erro ao obter todas as tarefas");
            }
        }
        [HttpGet]
        [Authorize]
        [Route("id")]
        public IActionResult GetById(int id)
        {
            try
            {
               var tasks = _taskService.GetById(id);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter tarefa");
                return StatusCode(500, "Erro ao obter tarefa");
            }
        }
        

        [HttpPost]
        [Authorize]
        [Route("register")]
        public IActionResult Create(TaskRegisterDto taskRegisterDto)
        {
            try
            {
                _taskService.Create(taskRegisterDto);
                return Ok("Tasks cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar tarefa");
                return StatusCode(500, "Erro ao criar tarefa");
            }
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _taskService.Delete(id);
                return Ok("Task deletada com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar tarefa");
                return StatusCode(500, "Erro ao deletar tarefa");
            }
        }
        [HttpPut]
        [Authorize]
        public IActionResult Put(TaskRegisterDto taskRegisterDto, int idTasks)
        {
            try
            {
                _taskService.Update(taskRegisterDto, idTasks);
                return Ok("Task atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar tarefa");
                return StatusCode(500, "Erro ao atualizar tarefa");
            }
            
        }

    }
}
