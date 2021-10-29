using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IAccountService
    {
        public Task<ApplicationUserModel> RegisterUser(RegisterModelDTO registerModel);
        public Task<bool> UpdateUserPassword(UpdateUserPasswordDTO updatePassword);
        public Task<UserDTO> UpdateUserData(UpdateUserDataDTO updateData);
        public Task<UserDTO> LoginUser(LoginModelDTO loginModel);
        public Task<UserDTO> ChangeEmail(ChangeEmailDTO changeEmail);
        public Task SignOut();
    }
}
