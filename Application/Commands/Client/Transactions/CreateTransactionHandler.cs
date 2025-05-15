using MediatR;

public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, ApiResponse<EmptyResult>>
{
    private readonly ITransactionRepository _repo;

    public CreateTransactionHandler(ITransactionRepository repo)
    {
        _repo = repo;
    }

    public async Task<ApiResponse<EmptyResult>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = new Transaction(request.AccountId, request.Type, request.Value);
        await _repo.AddAsync(transaction);
        return new ApiResponse<EmptyResult>(true, "Cadastrado com sucesso", new EmptyResult[0]);
    }
}
