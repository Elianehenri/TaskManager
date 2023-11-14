using TaskManager.Models;

namespace TaskManager.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId); // pegar um usuario pelo id
        User GetUserByLoginPassword(string email, string password); // logar um usuario
        void AddUser(User user);// adicionar um novo usuario
        void UpdateUser(User user);// atualizar um usuario
        void DeleteUser(User user);// deletar um usuario
        bool CheckEmail(string email); // verificar se o email ja existe

        
    }
}
