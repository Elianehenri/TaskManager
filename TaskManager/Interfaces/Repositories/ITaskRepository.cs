using System.Collections.Generic;
using System;
using TaskManager.Models;

namespace TaskManager.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        void Create(Tasks tasks);
        void Update(Tasks tasks);
        void Delete(Tasks tasks);
        Tasks GetById(int id);
        List<Tasks> GetAll();
        
        List<Tasks> GetAllByUserId(int userId);//lista tarefas por id de user
    }
}


//- [ ]  Criar uma nova tarefa
//- [ ] Listar todas as tarefas
//- [ ] Obter uma tarefa específica
//- [ ] Atualizar uma tarefa
//- [ ] Excluir uma tarefa