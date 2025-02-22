using SmartExpenses.Shared.Models;

namespace SmartExpenses.Data.Repository.IRepo
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User obj);
    }
}
