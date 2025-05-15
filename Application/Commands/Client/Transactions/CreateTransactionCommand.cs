using MediatR;

public record CreateTransactionCommand(string AccountId, bool Type, double Value) : IRequest<ApiResponse<EmptyResult>>;
