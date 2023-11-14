using TaskManager.Dtos;
using TaskManager.Interfaces.Repositories;
using TaskManager.Interfaces.Services;
using TaskManager.Models;
using TaskManager.Security;
using TaskManager.Utils;
using TaskManager.Validators;

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

        public void AddUser(UserRegisterDto userRegisterdto)
        {
            // Verificar email, nome, senha  vazios 
            if (string.IsNullOrEmpty(userRegisterdto.Email) || string.IsNullOrWhiteSpace(userRegisterdto.Email) ||
                 string.IsNullOrEmpty(userRegisterdto.Name) || string.IsNullOrWhiteSpace(userRegisterdto.Name) ||
                string.IsNullOrEmpty(userRegisterdto.Password) || string.IsNullOrWhiteSpace(userRegisterdto.Password))
            {
                throw new Exception("Email, nome e senha são obrigatórios");
            }
            // Verificar se o email está em um formato válido usando a classe EmailValidator
            if (!EmailValidator.IsValidEmail(userRegisterdto.Email))
            {
                throw new Exception("Formato Email inválido");
            }

            // Verificar se a senha é válida usando a classe PasswordValidator
            if (!PasswordValidator.IsValidPassword(userRegisterdto.Password))
            {
                throw new Exception("A senha não atende aos critérios de segurança");
            }
            // Verificar se o email já existe no banco de dados
            if (_userRepository.CheckEmail(userRegisterdto.Email))
            {
                throw new Exception("Email já cadastrado");

            }
            // inserir user
            var user = new User
            {
                Name = userRegisterdto.Name,
                Email = userRegisterdto.Email.ToLower(),
                Password = HashUtility.GenerateSHA256Hash(userRegisterdto.Password),
            };
            // salvar banco
            _userRepository.AddUser(user);

        }

        public bool CheckEmail(string email)
        {
            return _userRepository.CheckEmail(email);
        }

        public void DeleteUser(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            _userRepository.DeleteUser(user);
        }

        //public List<User> GetAllUsers()
        //{
        //    throw new NotImplementedException();
        //}

        public UserResponseDto GetUserById(int userId)
        {
            // Verificar se id é vazio
            if (userId == 0)
            {
                throw new Exception("Id é obrigatório");
            }
            // Verificar se id existe no banco de dados
            User user = _userRepository.GetUserById(userId) ?? throw new Exception("Id nao encontrado");
            // Retornar um objeto UaserResponseDto
            UserResponseDto userResponseDto = new()
            {

                Name = user.Name,
                Email = user.Email,

            };
            return userResponseDto;

        }

        public User GetUserByLoginPassword(string email, string password)
        {
            //verificar se email e senhaexiste no banco   de dados
            User user = _userRepository.GetUserByLoginPassword(email.ToLower(), HashUtility.GenerateSHA256Hash(password));
            return user ?? throw new Exception("Email ou senha inválidos");

        }

        public LoginResponseDto Login(LoginRequestDto loginRequestDto)
        {
            // Verificar se email e senha estão vazios ou inválidos
            if (string.IsNullOrEmpty(loginRequestDto.Email) || string.IsNullOrWhiteSpace(loginRequestDto.Email) ||
                               string.IsNullOrEmpty(loginRequestDto.Password) || string.IsNullOrWhiteSpace(loginRequestDto.Password))
            {
                throw new Exception("Email e senha são obrigatórios");
            }
            // Verificar se o email existe no banco de dados e se as credenciais estão corretas
            User user = _userRepository.GetUserByLoginPassword(loginRequestDto.Email.ToLower(), HashUtility.GenerateSHA256Hash(loginRequestDto.Password));
            if (user != null)
            {
                return new LoginResponseDto
                {

                    Name = user.Name,
                    Email = user.Email,
                    Token = TokenService.GenerateToken(user, _configuration["JWT:SecretKey"])
                };

            }
            else
            {
                throw new Exception("Email ou senha inválidos");
            }

        }

    

        public void UpdateUser(UserRequestDto userRequestdto, int? userId)
        {
            var userDb = _userRepository.GetUserById(userRequestdto.Id);

            userDb.Name = userRequestdto.Name;
            userDb.Email = userRequestdto.Email;
            userDb.Password = HashUtility.GenerateSHA256Hash(userRequestdto.Password);

            _userRepository.UpdateUser(userDb);
        }

    }
}
