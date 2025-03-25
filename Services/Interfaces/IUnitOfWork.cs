namespace Services.Interfaces
{
    public interface IUnitOfWork
    {

        Task BeginTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();
    }
}