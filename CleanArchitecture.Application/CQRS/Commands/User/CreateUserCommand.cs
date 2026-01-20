using MediatR;
using CleanArchitecture.Application.DTOs.Users;

namespace CleanArchitecture.Application.CQRS.Commands.User;

public record CreateUserCommand(CreateUserRequestDto Dto) : IRequest;