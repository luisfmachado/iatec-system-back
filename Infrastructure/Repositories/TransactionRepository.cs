using Microsoft.EntityFrameworkCore;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transaction>> GetAllAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task DeleteAsync(Transaction transaction)
    {
        var account = await _context.Accounts.FindAsync(transaction.AccountId);

        if (account == null)
            throw new Exception("Conta não encontrada.");

        if (transaction.Type == true)
        {
            account.Balance += transaction.Value;
        }
        else if (transaction.Type == false)
        {
            account.Balance -= transaction.Value;
        }

        _context.Accounts.Update(account);
        _context.Transactions.Remove(transaction);

        await _context.SaveChangesAsync();
    }

    public async Task AddAsync(Transaction transaction)
    {
        var account = await _context.Accounts.FindAsync(transaction.AccountId);

        if (account == null)
            throw new Exception("Conta não encontrada.");

        if (transaction.Type == true)
        {
            account.Balance -= transaction.Value;
        }
        else if (transaction.Type == false)
        {
            account.Balance += transaction.Value;
        }

        _context.Accounts.Update(account);
        await _context.Transactions.AddAsync(transaction);

        await _context.SaveChangesAsync();
    }

    public async Task<Transaction?> GetByIdAsync(int id)
    {
        return await _context.Transactions.FirstOrDefaultAsync(u => u.Id == id);
    }
}
