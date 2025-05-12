using MediatR;
using Microsoft.AspNetCore.Identity;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, ApiResponse<Guid>>
{
    private readonly IUserRepository _repo;
    private readonly IPasswordHasher<User> _passwordHasher;

    public CreateUserHandler(IUserRepository repo, IPasswordHasher<User> passwordHasher)
    {
        _repo = repo;
        _passwordHasher = passwordHasher;
    }

    public async Task<ApiResponse<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var existingUser = await _repo.GetByUsernameAsync(request.Username);
        if (existingUser != null)
        {
            return new ApiResponse<Guid>(false, "Username já está em uso.", null);
        }

        var user = new User(request.Name, request.Username, string.Empty, request.Role);
        user.Password = _passwordHasher.HashPassword(user, request.Password);
        await _repo.AddAsync(user);
        return new ApiResponse<Guid>(true, "Cadastrado com sucesso", new[] { user.Id });
    }
}
