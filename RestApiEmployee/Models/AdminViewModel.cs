using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RestApiEmployee.Models
{
    public class AdminViewModel : IRequest
    {   
        [Key]
        public int AdminId { get; private set; }
        public string AdminName { get; private set; }
        public string AdminSurname { get; private set; }

        public AdminViewModel(int adminId, string adminName, string adminSurname)
        {
            AdminId = adminId;
            AdminName = adminName;
            AdminSurname = adminSurname;
        }
    }
}
