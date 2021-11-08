using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Infrastructure.Service;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class AccountServiceTest
    {
        private ILogger<AccountService> _logger;
        private AccountService _service;

        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
            _logger = TestHelper.SetupTestLogger<AccountService>();
        }

        [Test]
        public async Task RegisterUserTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var dto = new RegisterModelDTO()
            {
                UserName = "User1",
                Profile = new UserProfileModelDTO()
                {
                    FirstName = "FirstName1",
                    LastName = " LastName1",
                    Birthday = DateTime.Now,
                    Gender = "male",
                    Address = new AddressModelDTO()
                    {
                        StreetName = "Vatutina"
                    }
                },
                Email = "bolibokvolodya@gmail.com",
                Password = "qwerty123",
            };

            var user = await accountService.RegisterUser(dto);
            var userFromContext = TestHelper.ApplicationContext.Users.FirstOrDefault(x => x.Email == dto.Email);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.UserName, userFromContext.UserName);
            Assert.AreEqual(user.Email, userFromContext.Email);
            Assert.AreEqual(user.Profile.FirstName, userFromContext.Profile.FirstName);
            Assert.AreEqual(user.Profile.LastName, userFromContext.Profile.LastName);
            Assert.AreEqual(user.Profile.Address.StreetName, userFromContext.Profile.Address.StreetName);
        }

        [Test]
        public async Task LoginUserTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var userLogin = TestHelper.ApplicationContext.Users.FirstOrDefault(x => x.UserName == "admin@admin.admin");
            var dto = new LoginModelDTO()
            {
                Login = userLogin.UserName,
                Password = userLogin.PasswordHash,
                Attempts = 0,
            };

            var user = await accountService.LoginUser(dto);
            var userFromContext = TestHelper.ApplicationContext.Users.FirstOrDefault(x => x.UserName == dto.Login);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.UserName, userFromContext.UserName);
            Assert.AreEqual(user.Email, userFromContext.Email);
            Assert.AreEqual(user.Profile.FirstName, userFromContext.Profile.FirstName);
        }
    }
}
