using CityWeb.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IUserManagementService : IServiceMetadata
    {
        public bool UpdateUserData(UpdateUserDataDTO user);
        public bool UnblockUser(Guid userId);
        public bool RemoveUser(Guid userId);
        public IEnumerable<UserDTO> GetUsers(int skip = 0, int take = 10); // ???
        public IEnumerable<UserDTO> GetUsers(IEnumerable<Guid> guids);
        public UserDTO GetUserById(Guid userId);
        public UserDTO GetUserByEmail(string email);
    }
}

