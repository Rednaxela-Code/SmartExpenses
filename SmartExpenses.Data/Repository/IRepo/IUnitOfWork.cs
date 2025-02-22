namespace SmartExpenses.Data.Repository.IRepo
{
    public interface IUnitOfWork
    {
        IExpenseRepository Expenses { get; }

        IUserRepository Users { get; }

        Task Save();
    }
}
