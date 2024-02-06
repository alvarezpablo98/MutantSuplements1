using MutantSuplements.API.Entities;

namespace MutantSuplements.API.DTOs.UserDTOs
{
    public class UsersDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        //public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
