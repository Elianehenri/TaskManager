using TaskManager.DataBase;
using TaskManager.Interfaces.Repositories;
using TaskManager.Models;

namespace TaskManager.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerDbContext _context;

        public TaskRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public void Create(Tasks tasks)
        {
            _context.Tasks.Add(tasks);
            _context.SaveChanges();
        }

        public void Delete(Tasks tasks)
        {
            _context.Tasks.Remove(tasks);
            _context.SaveChanges();
        }

        public List<Tasks> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public List<Tasks> GetAllByUserId(int userId)
        {
            //cria o metod de listar todas as trefas pelo id do user
            return _context.Tasks.Where(x => x.UserId == userId).ToList();


        }

        public Tasks GetById(int id)
        {
           return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Tasks tasks)
        {
            _context.Tasks.Update(tasks);
            _context.SaveChanges();
        }
    }
}
