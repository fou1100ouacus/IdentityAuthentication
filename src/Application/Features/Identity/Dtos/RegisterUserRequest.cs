using Application.Common.Interfaces;
using Application.Features.Identity.Dtos;
using Domain.Common.Results;

using MediatR;

namespace Application.Features.Identity.Dtos;

public record RegisterUserRequest(
    string Email,
    string Password,
    string? ConfirmPassword = null
) : IRequest<Result<string>>;   // returns User Id on success