using MediatR;
using Application.DTOs.Users;

namespace Application.CQRS.Queries.User;

public record GetUsersQuery() : IRequest<IEnumerable<UserResponseDto>>;
