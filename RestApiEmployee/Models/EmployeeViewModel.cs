using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RestApiEmployee.Models
{
    public class EmployeeViewModel : IRequest
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } 
        public string GivenName { get; set; }
    }
}
