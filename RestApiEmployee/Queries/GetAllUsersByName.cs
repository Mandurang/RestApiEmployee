using MediatR;
using System.Collections;
using RestApiEmployee.Models;

namespace RestApiEmployee.Queries
{
    public class GetAllUsersByName : IRequest<IEnumerable<UserViewModel>>
    {

    }

    //public class GetAllUsersByNameHandler : IRequestHandler<GetAllUsersByName,IEnumerable<UserViewModel>>
    //{
    //    private readonly 
    //}
}
