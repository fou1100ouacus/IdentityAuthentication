// using Application.Common.Interfaces;
// using Application.Features.Identity;
// using Domain.Common.Results;
// using MediatR;
// using Microsoft.AspNetCore.Identity;

// namespace Application.Features.Identity.Commands;

// public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, Result<TokenResponse>>
// {
//     private readonly IIdentityService _identityService;
//     private readonly ITokenProvider _tokenService;           // ← abstraction جديدة

//     public GenerateTokenCommandHandler(
//         IIdentityService identityService,
//         ITokenProvider tokenService)
//     {
//         _identityService = identityService;
//         _tokenService = tokenService;
//     }

//     public async Task<Result<TokenResponse>> Handle(
//         GenerateTokenCommand request,
//         CancellationToken ct)
//     {
//         var authResult = await _identityService.AuthenticateAsync(request.Email, request.Password);

//         if (!authResult.IsSuccess)
//         {
//             return Result<TokenResponse>.Failure(authResult.Errors);
//         }

//         var userDto = authResult.Value;

//         // توليد التوكن باستخدام الـ abstraction
//         var accessToken = _tokenService.GenerateJwtTokenAsync(
//             userId: userDto.Id,
//             email: userDto.Email,
//             roles: userDto.Roles.Select(r => r.Name).ToList()
//         );
 
//         var refreshToken = _tokenService.GenerateRefreshToken();

//         var expiresOn = _tokenService.GetAccessTokenExpiryUtc();  // أو DateTime.UtcNow.AddMinutes(60)

//         var response = new TokenResponse
//         {
//             AccessToken = accessToken,
//             RefreshToken = refreshToken,
//             ExpiresOnUtc = expiresOn
//         };

//         // optional: احفظ refresh token في DB لو عايز (في خطوة لاحقة)
//         // await _tokenService.StoreRefreshTokenAsync(userDto.Id, refreshToken, expiresOn.AddDays(7));

//         return Result<TokenResponse>.Success(response);
//     }
// }