using Microsoft.EntityFrameworkCore;

namespace TaskApp.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}