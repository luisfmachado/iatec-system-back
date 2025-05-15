using MediatR;

public record DeleteAccountCommand(int Id) : IRequest<bool>;