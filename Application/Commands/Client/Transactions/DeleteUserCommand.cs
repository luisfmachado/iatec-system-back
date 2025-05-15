using MediatR;

public record DeleteTransactionCommand(int Id) : IRequest<bool>;
