public class LoginResult
{
    public string Token { get; set; }

    public LoginResult(string token)
    {
        Token = token;
    }
}
