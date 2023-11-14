using TaskManager.Interfaces.Repositories;
using TaskManager.Repository;

namespace TaskManager.Config
{
    public class RepositoryIoc
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped<IUserRepository, UserRepository>();
            builder.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}
