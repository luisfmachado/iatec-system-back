public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task AddAsync(User user);
    Task DeleteAsync(User user);
    Task<User?> GetByUsernameAsync(string username);

}
