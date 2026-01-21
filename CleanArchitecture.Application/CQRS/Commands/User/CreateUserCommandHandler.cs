using MediatR;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.CQRS.Commands.User;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _repository;

    public CreateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        
        var user = new Domain.Entities.User(
            request.Dto.Username,
            request.Dto.Useremail,
           CleanPhoneNumber(request.Dto.UserPhone)
        );

        await _repository.AddAsync(user);
    }

    private string CleanPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return string.Empty;

        // Remove caracteres não numéricos (parênteses, hífens, espaços, etc)
        return new string(phoneNumber.Where(char.IsDigit).ToArray());
    }
}
