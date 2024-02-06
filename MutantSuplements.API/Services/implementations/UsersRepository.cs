using Microsoft.EntityFrameworkCore;
using MutantSuplements.API.DBContext;
using MutantSuplements.API.DTOs.UserDTOs;
using MutantSuplements.API.Entities;
using MutantSuplements.API.Services.interfaces;

namespace MutantSuplements.API.Services.implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MutantSuplementsContext _context;
        public UsersRepository(MutantSuplementsContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public IEnumerable<User> GetUsersWithoutOrders()
        {
            return _context.Users;
        }

        //public User? GetUserWithoutOrder(int idUser) // 
        //{
        //    return _context.Users.FirstOrDefault(u => u.Id == idUser);
        //}

        public User? GetUser(int idUser)
        {
            return _context.Users.FirstOrDefault(u => u.Id == idUser);
        }

        public void AddUser(User newUser)
        {
            _context.Users.Add(newUser);
        }

        public void Update(User user)
        {
            _context.Update(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public bool EmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool UserNameExists(string name)
        {
            return _context.Users.Any(u => u.UserName == name);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public User? ValidateCredentials(UserLoginDTO authParams)
        {
            return _context.Users.FirstOrDefault(u => u.Email == authParams.Email && u.Password == authParams.Password);
        }

    }
}
