using CounselingCenter.Core.Configuration;
using CounselingCenter.Core.Dtos;
using CounselingCenter.Core.Models;

namespace CounselingCenter.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser appUser);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}