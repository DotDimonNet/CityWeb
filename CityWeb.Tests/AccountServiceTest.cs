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
        private Mock<ILogger<AccountService>> _loggerMock;
        private AccountService _service;

        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
            _loggerMock = TestHelper.SetupTestLogger(new NullLogger<AccountService>());
        }

        [Test]
        public async Task RegisterUserTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper);
            var dto = new RegisterModelDTO()
            {
                UserName = "User1",
                Profile = new UserProfileModelDTO()
                {
                    FirstName = "FirstName1",
                    LastName = " LastName1",
                    Birthday = DateTime.Now,
                    Gender = "male",
                },
                Email = "emailTest@gmail.com",
                Password = "qwerty123",
            };

            var user = await accountService.RegisterUser(dto);
            var userFromContext = TestHelper.ApplicationContext.Users.FirstOrDefault(x => x.Email == dto.Email);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.Email, userFromContext.Email);
            Assert.AreEqual(user.UserName, userFromContext.UserName);
            Assert.AreEqual(user.PasswordHash, userFromContext.PasswordHash);
        }
    }
}
