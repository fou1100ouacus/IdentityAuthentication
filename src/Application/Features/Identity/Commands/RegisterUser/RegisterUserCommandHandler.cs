using Application.Common.Interfaces;
using Domain.Common.Results;
using MediatR;

namespace Application.Features.Identity.Commands.RegisterUser;

public class RegisterUserCommandHandler 
    : IRequestHandler<RegisterUserCommand, Result<string>>
{
    private readonly IIdentityService _identityService;

    public RegisterUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result<string>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        return await _identityService.RegisterUserAsync(
            request.Email,
            request.Password,
            cancellationToken);
    }
}