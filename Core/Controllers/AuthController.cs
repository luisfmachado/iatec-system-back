using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        if (string.IsNullOrEmpty(command.Username) || string.IsNullOrEmpty(command.Password))
        {
            return BadRequest(new ApiResponse<object>(false, "Usuário ou senha inválidos.", null));
        }

        var token = await _mediator.Send(command);

        if (token == null)
        {
            return Unauthorized(new ApiResponse<object>(false, "Usuário ou senha incorretos.", null));
        }

        return Ok(new ApiResponse<LoginResult>(true, "Login bem-sucedido.", new[] { new LoginResult(token) }));
    }
}
