public interface ITransactionRepository
{
    Task<List<Transaction>> GetAllAsync();
    Task<Transaction?> GetByIdAsync(int id);
    Task AddAsync(Transaction transaction);
    Task DeleteAsync(Transaction transaction);

}
