using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Services.IService
{
    public interface IUserService
    {
        Task<bool> Add(User obj);
        IEnumerable<User> GetAll();
        User GetUser(int id);
        Task<bool> DeleteUser(User user);
        Task<User> UpdateUser(User user);
    }
}
