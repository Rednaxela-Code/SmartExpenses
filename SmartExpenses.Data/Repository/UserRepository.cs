using SmartExpenses.Data.Database;
using SmartExpenses.Data.Repository.IRepo;
using SmartExpenses.Shared.Models;

namespace SmartExpenses.Data.Repository
{
    class UserRepository(AppDbContext db) : Repository<User>(db), IUserRepository
    {
        private readonly AppDbContext _db = db;

        public void Update(User obj)
        {
            _db.Update(obj);
        }
    }
}
