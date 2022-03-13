using System.Threading.Tasks;
using CounselingCenter.Core.Dtos;
using SharedLibrary.Dtos;

namespace CounselingCenter.Core.Services
{
    public interface IUserService
    {
        Task<Response<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<AppUserDto>> GetUserByNameAsync(string userName);
    }
}