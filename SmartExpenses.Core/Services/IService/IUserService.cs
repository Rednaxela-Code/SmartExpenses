using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Services.IService
{
    public interface IUserService
    {
        Task<bool> Add(User obj);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUser(int id);
    }
}
