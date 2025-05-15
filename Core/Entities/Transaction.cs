public class Transaction
{
    public int Id { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public bool Type { get; set; }
    public double Value {get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Transaction(string accountId, bool type, double value)
    {
        AccountId = accountId;
        Type = type;
        Value = value;
    }
}