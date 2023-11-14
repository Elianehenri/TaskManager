using TaskManager.Dtos;
using TaskManager.Models;

namespace TaskManager.Interfaces.Services
{
    public interface ITaskService
    {
        void Create(TaskRegisterDto taskRegisterDto);
        void Update(TaskRegisterDto taskRegisterDto, int idTasks);
        void Delete(int id);
        TaskResponseDto GetById(int id);
        List<Tasks> GetAll(int userId);

        //List<Tasks> GetAllByUserId(int userId);//lista tarefas por id de user

    }
}
