using MediatR;
using RestApiEmployee.Models;

namespace RestApiEmployee.Queries
{
    public static class CreateEmployee
    {
        public record EmployeeEntity (string name, string surname) : IRequest<int>;

        public class Handler : IRequestHandler<EmployeeEntity, int>
        {
            private readonly DbEmployeeRepo _dbEmployeeRepo;

            public Handler(DbEmployeeRepo dbEmployeeRepo)
            {
                _dbEmployeeRepo = dbEmployeeRepo;
            }
            
            public Task<int> Handle(EmployeeEntity request, CancellationToken cancellationToken)
            {
                return _dbEmployeeRepo.Create(new EmployeeViewModel { Name = request.name, Surname = request.surname });
            }
        }
    }
}
