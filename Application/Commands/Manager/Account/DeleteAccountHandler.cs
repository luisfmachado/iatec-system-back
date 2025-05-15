using MediatR;

public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, bool>
{
    private readonly IAccountRepository _repo;

    public DeleteAccountHandler(IAccountRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _repo.GetByIdAsync(request.Id);
        if (account == null) return false;

        await _repo.DeleteAsync(account);
        return true;
    }
}
