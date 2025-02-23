using SmartExpenses.Core.Services.IService;
using SmartExpenses.Core.Validators;
using SmartExpenses.Data.Repository.IRepo;
using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(User obj)
        {
            if (UserValidators.IsValidUser(obj))
            {
                await _unitOfWork.Users.Add(obj);
                await _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _unitOfWork.Users.GetAll();
            if (!users.Any())
            {
                return [];
            }
            return users;

        }

        public async Task<User> GetUser(int id)
        {
            User? user = await _unitOfWork.Users.GetFirstOrDefault(u => u.Id == id);
            if (user.IsValidUser())
            {
                return user!;
            }
            return new();
        }

        public async Task<bool> Update(User obj)
        {
            if (UserValidators.IsValidUser(obj))
            {
                _unitOfWork.Users.Update(obj);
                await _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _unitOfWork.Users.GetFirstOrDefault(u => u.Id == id);
            if (user.IsValidUser())
            {
                await _unitOfWork.Users.Remove(user!);
                await _unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
