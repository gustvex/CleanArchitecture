using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Users;
using Application.CQRS.Commands.User;
using Application.CQRS.Queries.User;

namespace Presentation.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequestDto dto)
    {
        await _mediator.Send(new CreateUserCommand(dto));
        return Created("", null);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _mediator.Send(new GetUsersQuery());
        return Ok(users);
    }
}
