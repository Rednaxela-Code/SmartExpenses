using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Services.IService
{
    public interface IUserService
    {
        Task<bool> Add(User obj);
    }
}
