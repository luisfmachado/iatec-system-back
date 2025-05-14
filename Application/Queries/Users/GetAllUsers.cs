using MediatR;

public record GetAllUsersQuery(): IRequest<List<UserDto>>;