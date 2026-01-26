using MediatR;
using Application.DTOs.Users;

namespace Application.CQRS.Commands.User;

public record CreateUserCommand(CreateUserRequestDto Dto) : IRequest;