using MutantSuplements.API.DTOs.UserDTOs;
using MutantSuplements.API.Entities;

namespace MutantSuplements.API.Services.interfaces
{
    public interface IUsersRepository
    {
        public IEnumerable<User> GetUsers();
        public IEnumerable<User> GetUsersWithoutOrders();
        public User? GetUser(int idUser);
        void AddUser(User newUser);
        void DeleteUser(User user);
        bool EmailExists(string email);
        bool UserNameExists(string name);
        bool SaveChanges();
        User? ValidateCredentials(UserLoginDTO authParams);
        void Update(User user);
    }
}
