using Microsoft.AspNetCore.Mvc;
using TaskManager.Controllers;
using TaskManager.Dtos;
using TaskManager.Interfaces.Repositories;
using TaskManager.Interfaces.Services;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        
    

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            
            
        }

        public void Create(TaskRegisterDto taskRegisterDto)
        {
            // Verificar se nome está vazio 
            if (string.IsNullOrEmpty(taskRegisterDto.Title))
            {
                throw new Exception("O título é obrigatório");
            }

            Tasks tasks = new ()
            {
                Title = taskRegisterDto.Title,
                Description = taskRegisterDto.Description,
                StartDate = taskRegisterDto.StartDate,
                EndDate = taskRegisterDto.EndDate,
                Status = taskRegisterDto.Status,
                UserId = taskRegisterDto.UserId

            };
            _taskRepository.Create(tasks);

        }

        public void Delete(int id)
        {
           
            Tasks tasks = _taskRepository.GetById(id) ?? throw new Exception("Tarefa não encontrada");
            _taskRepository.Delete(tasks);
        }

       
        public List<Tasks> GetAll(int userId)
        {
            try
            {
                // Obter todas as tarefas
                List<Tasks> allTasks = _taskRepository.GetAll() ?? throw new Exception("Erro ao obter  as tarefas");

                // Filtrar tarefas com base no ID do usuário
                List<Tasks> userTasks = allTasks.Where(task => task.UserId == userId).ToList();

                
                if (userTasks.Count == 0)
                {
                    // Se não houver tarefas para o usuário
                    throw new Exception("Nenhuma tarefa encontrada para o usuário especificado");
                }

                return userTasks;
            }
            catch (Exception )
            {
                throw ;
                
               


            }
        }


        

        public TaskResponseDto GetById(int id)
        {
            // Verificar se id existe no banco de dados
            Tasks tasks = _taskRepository.GetById(id) ?? throw new Exception("Tarefa não encontrada");

            // Mapear Tasks para TaskResponseDto
            TaskResponseDto taskResponseDto = new ()
            {
                Id = tasks.Id,
                Title = tasks.Title,
                Description = tasks.Description,
                StartDate = tasks.StartDate,
                EndDate = tasks.EndDate,
                Status = tasks.Status,
            };
            return taskResponseDto;

        }


        public void Update(TaskRegisterDto taskRegisterDto, int idTasks)
        {
            //verificar se id existe no banco de dados
            Tasks tasks = _taskRepository.GetById(idTasks) ?? throw new Exception("Tarefa não encontrada");
            //atualizar os campos da tarefa com os dados do taskRegisterDto
            tasks.Title = taskRegisterDto.Title; 
            tasks.Description = taskRegisterDto.Description;
            tasks.StartDate = taskRegisterDto.StartDate;
            tasks.EndDate = taskRegisterDto.EndDate;
            tasks.Status = taskRegisterDto.Status;

            //atualizar a tarefa no banco de dados
            _taskRepository.Update(tasks);
        }
    }
}
