public interface IAccountRepository
{
    Task<List<AccountDto>> GetAllAsync();
    Task<Account?> GetByIdAsync(int id);
    Task AddAsync(Account account);
    Task DeleteAsync(Account account);

}
