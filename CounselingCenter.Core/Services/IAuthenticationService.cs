using System.Threading.Tasks;
using CounselingCenter.Core.Dtos;
using SharedLibrary.Dtos;

namespace CounselingCenter.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken);
        Task<Response<NoDataDto>> RevokeRefreshTokenAsync(string refreshToken);
        Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
    }
}