using TaskManager.Interfaces.Services;
using TaskManager.Services;

namespace TaskManager.Config
{
    public class ServicoIoc
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped<IUserService, UserService>();
           // builder.AddScoped<ITaskService, TaskService>();
        }
    }
}
