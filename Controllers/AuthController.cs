using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;
    private readonly AppDbContext _context;

    public AuthController(JwtService jwtService, AppDbContext context)
    {
        _jwtService = jwtService;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User model)
    {
        if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
        {
            return BadRequest(new ApiResponse<object>(false, "Usuário ou senha inválidos.", null));
        }

        var user = _context.Users.FirstOrDefault(u => u.Username == model.Username);

        // Verifica se o usuário foi encontrado
        if (user == null)
        {
            return Unauthorized(new ApiResponse<object>(false, "Usuário ou senha incorretos.", null));
        }

        var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);

        // Verifica se a senha está correta
        if (result == PasswordVerificationResult.Success)
        {
            var token = _jwtService.GenerateToken(user.Username);
            return Ok(new ApiResponse<string>(true, "Login bem-sucedido.", token));
        }

        return Unauthorized(new ApiResponse<object>(false, "Usuário ou senha incorretos.", null));
    }
}