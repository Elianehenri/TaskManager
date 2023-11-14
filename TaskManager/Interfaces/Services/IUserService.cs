using TaskManager.Dtos;
using TaskManager.Models;

namespace TaskManager.Interfaces.Services
{
    public interface IUserService
    {
        public User GetUserByLoginPassword(string email, string password); //obter usuario pelo email e senha
        public LoginResponseDto Login(LoginRequestDto loginRequestDto); // login
        UserResponseDto GetUserById(int userId); // pegar um usuario pelo id

        void AddUser(UserRegisterDto userRegisterdto);// adicionar um novo usuario
        void UpdateUser(UserRequestDto userRequestdto, int? userId);// atualizar um usuario
        void DeleteUser(int userId);// deletar um usuario
        bool CheckEmail(string email); // verificar se o email ja existe

        //List<User> GetAllUsers();// pegar todos os usuarios
    }
}
