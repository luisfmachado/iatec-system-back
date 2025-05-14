public interface IAccountRepository
{
    Task<List<AccountDto>> GetAllAsync();
    Task AddAsync(Account account);
    Task DeleteAsync(Account account);

}
