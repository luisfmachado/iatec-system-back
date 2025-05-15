using MediatR;

public record GetAllTransactionsQuery(): IRequest<List<Transaction>>;