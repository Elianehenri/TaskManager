using TaskManager.Dtos;
using TaskManager.Models;

namespace TaskManager.Interfaces.Services
{
    public interface IUserService 
    {
        public User GetUserByLoginPassword(string email, string password); //obter usuario pelo email e senha
        //todo login response
        UserResponseDto GetUserById(int userId); // pegar um usuario pelo id
        
        void AddUser(UserRequestDto user);// adicionar um novo usuario
        void UpdateUser(User user);// atualizar um usuario
        void DeleteUser(User user);// deletar um usuario
        bool CheckEmail(string email); // verificar se o email ja existe

        List<User> GetAllUsers();// pegar todos os usuarios
    }
}
