using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, string?>
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly JwtService _jwtService;

    public LoginUserHandler(AppDbContext context, IPasswordHasher<User> passwordHasher, JwtService jwtService)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<string?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);

        if (user == null)
            return null;

        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

        if (result == PasswordVerificationResult.Success)
        {
            var token = _jwtService.GenerateToken(user.Username);
            return token;
        }

        return null;
    }
}
