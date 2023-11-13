using TaskManager.Interfaces.Repositories;
using TaskManager.Interfaces.Services;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public void AddUser(User user)
        {
            // Verificar email, nome, senha  vazios
            if (string.IsNullOrEmpty(user.Email) 
                || string.IsNullOrEmpty(user.Name) 
                || string.IsNullOrEmpty(user.Password))
            {
                throw new Exception("Email, nome e senha são obrigatórios");
            }
        }

        public bool CheckEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLoginPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
