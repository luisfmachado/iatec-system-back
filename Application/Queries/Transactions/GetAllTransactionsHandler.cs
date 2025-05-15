using MediatR;
using AutoMapper;

public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, List<Transaction>>
{
    private readonly ITransactionRepository _repo;
    private readonly IMapper _mapper;

    public GetAllTransactionsHandler(ITransactionRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<Transaction>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transaction = await _repo.GetAllAsync();
        return _mapper.Map<List<Transaction>>(transaction);
    }
}
