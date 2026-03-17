using Application.Common.Interfaces;
using Application.Features.Identity.Dtos;
using Domain.Common.Results;

using MediatR;

namespace Application.Features.Identity.Commands.RegisterUser;

public record RegisterUserCommand(
    string Email,
    string Password,
    string? ConfirmPassword = null
) : IRequest<Result<string>>;   // returns User Id on success