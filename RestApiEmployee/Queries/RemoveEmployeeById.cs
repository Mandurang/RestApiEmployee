using MediatR;

namespace RestApiEmployee.Queries
{
    public class RemoveEmployeeById : IRequest
    {
        public int Id { get; set; }
    }

    public class RemoveEmployeeByIdQueryHandler : IRequestHandler<RemoveEmployeeById, Unit>
    {
        private readonly DbEmployeeRepo _dbEmployeeRepo;

        public RemoveEmployeeByIdQueryHandler(DbEmployeeRepo dbEmployeeRepo)
            => _dbEmployeeRepo = dbEmployeeRepo;

        public async Task<Unit> Handle(RemoveEmployeeById request, CancellationToken cancellationToken)
        {
            if (await _dbEmployeeRepo.GetOne(request.Id) is null)
                throw new Exception("Item not found");

            await _dbEmployeeRepo.RemoveOne(request.Id);
            return Unit.Value;
        }
    }
}
