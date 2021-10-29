using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Infrastructure.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    class AccountServiceTest
    {
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
        }

        //[Test]
        //public async Task RegisterUserTest()
        //{
        //    var accountService = new AccountService(TestHelper.ApplicationContext, SignInManagerMock);
        //    var dto = new RegisterModelDTO()
        //    {
        //        UserName = "User1",
        //        FirstName = "FirstName1",
        //        LastName = " LastName1",
        //        Birthday = DateTime.Now,
        //        Gender = "male",
        //        Email = "emailTest@gmail.com",
        //        Password = "qwerty123",
        //    };

        //    var user = await accountService.RegisterUser(dto);
        //    var userFromContext = TestHelper.ApplicationContext.Users.FirstOrDefault(x => x.Email == dto.Email);
        //}
    }
}
