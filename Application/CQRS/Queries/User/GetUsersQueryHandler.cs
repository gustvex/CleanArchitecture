using MediatR;
using Domain.Interfaces;
using Application.DTOs.Users;

namespace Application.CQRS.Queries.User;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserResponseDto>>
{
    private readonly IUserRepository _repository;

    public GetUsersQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UserResponseDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync();

        return users.Select(u => new UserResponseDto
        {
            Id = u.Id,
            Username = u.Username,
            Useremail = u.Useremail,
            UserPhone = u.Userphone
            
        });
    }
}
