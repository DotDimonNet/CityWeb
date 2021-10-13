﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure.Enums;

namespace CityWeb.Infrastructure.Interfaces
{
    public interface IUserManagementService : IServiceMetadata
    {
        public IEnumerable<IUser> Users { get; set; }
        public bool UpdateUserData(IUser user);
        public bool UnblockUser(Guid userId);
        public bool RemoveUser(Guid userId);
        public IEnumerable<IUser> GetUsers(int skip = 0, int take = 10); // ???
        public IEnumerable<IUser> GetUsers(IEnumerable<Guid> guids);
        public IUser GetUserById(Guid userId);
        public IUser GetUserByEmail(string email);

        //public bool BlockUser(Guid userId);
        //public bool CreateUser(Guid userId);
    }
}

