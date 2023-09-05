using Microsoft.EntityFrameworkCore;
using ToDoListDomain_0.Entity_0;

namespace ToDoListDal_0
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
