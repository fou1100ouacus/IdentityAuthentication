using Domain.Common.Results;
using MediatR;

namespace Application.Features.Identity.Commands;

public record LoginUserCommand(string Email, string Password)
    : IRequest<Result<TokenResponse>>;