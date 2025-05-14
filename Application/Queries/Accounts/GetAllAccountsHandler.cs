using MediatR;
using AutoMapper;

public class GetAllAccountsHandler : IRequestHandler<GetAllAccountsQuery, List<AccountDto>>
{
    private readonly IAccountRepository _repo;
    private readonly IMapper _mapper;

    public GetAllAccountsHandler(IAccountRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<AccountDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
    {
        var usuarios = await _repo.GetAllAsync();
        return _mapper.Map<List<AccountDto>>(usuarios);
    }
}
