using MediatR;

public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, ApiResponse<EmptyResult>>
{
    private readonly IAccountRepository _repo;

    public CreateAccountHandler(IAccountRepository repo)
    {
        _repo = repo;
    }

    public async Task<ApiResponse<EmptyResult>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var user = new Account(request.UserId, request.Bank, true);
        await _repo.AddAsync(user);
        return new ApiResponse<EmptyResult>(true, "Cadastrado com sucesso", new EmptyResult[0]);
    }
}
