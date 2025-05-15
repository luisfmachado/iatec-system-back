using Microsoft.EntityFrameworkCore;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AccountDto>> GetAllAsync()
    {
        return await (
            from a in _context.Accounts
            join u in _context.Users on a.UserId equals u.Id.ToString()
            select new AccountDto
            {
                Id = a.Id,
                UserId = u.Id,
                Username = u.Name,
                isActive = a.IsActive,
                Balance = a.Balance
            }
        ).ToListAsync();
    }

    public async Task DeleteAsync(Account account)
    {
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }

    public async Task AddAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }

    public async Task<Account?> GetByIdAsync(int id)
    {
        return await _context.Accounts.FirstOrDefaultAsync(u => u.Id == id);
    }
}
