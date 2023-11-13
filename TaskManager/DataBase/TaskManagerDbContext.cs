using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.DataBase
{
    public class TaskManagerDbContext : DbContext
    {
        // Crie um construtor
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
        {
        }

        // Adicione propriedades para as classes
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        // Adicione um método para configurar o modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().ToTable("Tasks");
            modelBuilder.Entity<Tasks>().HasKey(t => t.Id);

            // Configure as propriedades StartDate e EndDate como Date
            modelBuilder.Entity<Tasks>()
                .Property(t => t.StartDate)
                .HasColumnType("date"); // Configura o tipo da coluna como "date"

            modelBuilder.Entity<Tasks>()
                .Property(t => t.EndDate)
                .HasColumnType("date"); // Configura o tipo da coluna como "date"

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.Id);
        }
    }
}




