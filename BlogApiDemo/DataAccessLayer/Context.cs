using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.Controllers.DataAccessLayer
{
    public class Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-KB4N4TR;database=CoreBlogApiDb;integrated security=true;");
            //base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
