using MediatR;
using AutoMapper;

public class GetAllUsuariosHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly IUserRepository _repo;
    private readonly IMapper _mapper;

    public GetAllUsuariosHandler(IUserRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var usuarios = await _repo.GetAllAsync();
        return _mapper.Map<List<UserDto>>(usuarios);
    }
}
