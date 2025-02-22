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
            if (UserValidators.IsValid(obj))
            {
                await _unitOfWork.Users.Add(obj);
                await _unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
