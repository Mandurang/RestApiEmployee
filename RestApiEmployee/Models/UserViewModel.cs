using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RestApiEmployee.Models
{
    public class UserViewModel : IRequest
    {
        [Key]
        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public string UserSurname { get; private set; }

        public UserViewModel(int userId, string userName, string userSurname)
        {
            UserId = userId;
            UserName = userName;
            UserSurname = userSurname;
        }
    }

}
