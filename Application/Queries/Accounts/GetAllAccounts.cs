using MediatR;

public record GetAllAccountsQuery(): IRequest<List<AccountDto>>;