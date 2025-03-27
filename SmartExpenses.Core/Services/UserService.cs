using SmartExpenses.Core.Services.IService;
using SmartExpenses.Core.Validators;
using SmartExpenses.Data.Database;
using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Add(User obj)
        {
            if (UserValidators.IsValidUser(obj))
            {
                _db.Users.Add(obj);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _db.Users.ToList();
            if (!users.Any())
            {
                return [];
            }
            return users;

        }

        public User GetUser(int id)
        {
            User? user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user.IsValidUser())
            {
                return user!;
            }
            return new();
        }

        public async Task<bool> DeleteUser(User user)
        {
            if (user.IsValidUser())
            {
                _db.Users.Remove(user!);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<User> UpdateUser(User user)
        {
            if (user.IsValidUser())
            {
                _db.Users.Update(user!);
                await _db.SaveChangesAsync();
                return user;
            }
            return new();
        }
    }
}
