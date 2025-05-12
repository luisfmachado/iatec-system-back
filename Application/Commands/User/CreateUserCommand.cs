using MediatR;

public record CreateUserCommand(string Name, string Username, string Password, string Role) : IRequest<ApiResponse<Guid>>;
