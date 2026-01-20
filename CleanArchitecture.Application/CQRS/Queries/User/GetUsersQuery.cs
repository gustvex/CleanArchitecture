using MediatR;
using CleanArchitecture.Application.DTOs.Users;

namespace CleanArchitecture.Application.CQRS.Queries.User;

public record GetUsersQuery() : IRequest<IEnumerable<UserResponseDto>>;
