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

        public Task<EmployeeViewModel> GetOne(int id)
            => _dbContextEmployee.EmployeeViewModels.FirstOrDefaultAsync(c => c.Id == id);

        public Task<EmployeeViewModel> GetOne(string name)
            => _dbContextEmployee.EmployeeViewModels.FirstOrDefaultAsync(c => c.Name == name);

        public async Task<int> Create(EmployeeViewModel employeeViewModel)
        {
            await _dbContextEmployee.EmployeeViewModels.AddAsync(employeeViewModel);
            await _dbContextEmployee.SaveChangesAsync();
            return employeeViewModel.Id;
        }

        public async Task RemoveOne(int id)
        {
            var employee = await GetOne(id);
            _dbContextEmployee.EmployeeViewModels.Remove(employee);
            await _dbContextEmployee.SaveChangesAsync();
        }

        public async Task UpdateEmployee (int id, string name, string givenName, string password)
        {
            var employeeView = await GetOne(id);
            _dbContextEmployee.EmployeeViewModels.Update(employeeView);
            await _dbContextEmployee.SaveChangesAsync();
        }

    }
}
