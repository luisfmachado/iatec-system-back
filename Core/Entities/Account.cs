public class Account
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Bank { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public double Balance {get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Account(string userId, string bank, bool isActive)
    {
        UserId = userId;
        Bank = bank;
        IsActive = isActive;
    }
}