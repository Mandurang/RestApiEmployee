using Microsoft.EntityFrameworkCore;
using RestApiEmployee.Models;

namespace RestApiEmployee.Persistance
{
    public class DbContextEmployee : DbContext
    {
        public DbContextEmployee(DbContextOptions<DbContextEmployee> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AdminViewModel> AdminViewModels { get; set; }
        public DbSet<UserViewModel> UserViewModels { get; set; }
        public DbSet<EmployeeViewModel> EmployeeViewModels { get; set; }
    }
}
