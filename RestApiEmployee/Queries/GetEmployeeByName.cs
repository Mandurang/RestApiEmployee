using MediatR;
using System.Collections;
using RestApiEmployee.Models;

namespace RestApiEmployee.Queries
{
    public class GetEmployeeByName : IRequest<EmployeeViewModel>
    {
        public string Name { get; set; }
    }

    public class GetUserByNameQueryHandler : IRequestHandler<GetEmployeeByName, EmployeeViewModel>
    {
        private readonly DbEmployeeRepo _dbEmployeeRepo;

        public GetUserByNameQueryHandler(DbEmployeeRepo dbEmployeeRepo)
            => _dbEmployeeRepo = dbEmployeeRepo;

        public Task<EmployeeViewModel> Handle(GetEmployeeByName request, CancellationToken cancellationToken)
            => _dbEmployeeRepo.GetOne(request.Name);

    }
}
