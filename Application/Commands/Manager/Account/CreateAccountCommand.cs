using MediatR;

public record CreateAccountCommand(string UserId, string Bank, bool IsActive) : IRequest<ApiResponse<EmptyResult>>;
