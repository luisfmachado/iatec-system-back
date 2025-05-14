public class AccountDto 
{

    public int Id { get; set; } 
    public Guid UserId {get; set;}
    public string Username { get; set; } 
    public bool isActive { get; set; }
    public double Balance { get; set; }

}