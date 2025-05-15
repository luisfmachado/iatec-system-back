using MediatR;

public class DeleteTransactionHandler : IRequestHandler<DeleteTransactionCommand, bool>
{
    private readonly ITransactionRepository _repo;

    public DeleteTransactionHandler(ITransactionRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _repo.GetByIdAsync(request.Id);
        if (transaction == null) return false;

        await _repo.DeleteAsync(transaction);
        return true;
    }
}
