using MediatR;

namespace RestApiEmployee.Queries
{
    public class UpdateEmployee
    {
        public record Parametrs(int Id, string Name, string GivenName, string Password) : IRequest;

        public class Handler : IRequestHandler<Parametrs>
        {
            private readonly DbEmployeeRepo _dbEmployeeRepo;

            public Handler(DbEmployeeRepo dbEmployeeRepo)
            {
                _dbEmployeeRepo = dbEmployeeRepo;
            }

            public async Task<Unit> Handle(Parametrs request, CancellationToken cancellationToken)
            {
                if (await _dbEmployeeRepo.GetOne(request.Id) is null)
                    throw new Exception("Item not found");
                await _dbEmployeeRepo.UpdateEmployee(request.Id, request.Name, request.GivenName, request.Password);
                return Unit.Value;
            }
        }
    }
}
