using RestApiEmployee.Models;

namespace RestApiEmployee
{
    public class DbEmployeeRepo
    {
        private readonly DbContextEmployee _dbContextEmployee;

        public DbEmployeeRepo(DbContextEmployee dbContextEmployee)
        {
            _dbContextEmployee = dbContextEmployee;
        }

        public Task<EmployeeViewModel> GetOne(string name)
            => _dbContextEmployee.EmployeeViewModels.FirstOrDefaultAsync(c => c.Name == name);
    }
}
