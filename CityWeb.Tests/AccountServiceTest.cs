using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
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

        [Test]
        public async Task LoginUserExceptionTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var userLogin = TestHelper.ApplicationContext.Users.FirstOrDefault(x => x.UserName == "admin@admin.admin");
            var dto = new LoginModelDTO()
            {
                Login = "User1",
                Password = userLogin.PasswordHash,
                Attempts = 0,
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await accountService.LoginUser(dto));
            Assert.AreEqual(exeption.Message, "User not exist!");
        }

        [Test]
        public async Task UpdateUserDataTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var user = TestHelper.ApplicationContext.Users.FirstOrDefault(x => x.UserName == "admin@admin.admin");
            var dto = new UpdateUserDataDTO()
            {
                UserId = user.Id,
                Profile = new UserProfileModelDTO()
                {
                    FirstName = "Gora",
                    Address = new AddressModelDTO()
                    {
                        StreetName = "Tyagyk"
                    }
                },
            };

            var updatedUser = await accountService.UpdateUserData(dto);

            Assert.IsNotNull(updatedUser);
            Assert.AreEqual(updatedUser.UserName, user.UserName);
            Assert.AreEqual(updatedUser.Profile.FirstName, user.Profile.FirstName);
            Assert.AreEqual(updatedUser.Profile.Address.StreetName, user.Profile.Address.StreetName);
        }

        [Test]
        public async Task UpdateUserDataExceptionTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var dto = new UpdateUserDataDTO()
            {
                UserId = Guid.NewGuid(),
                Profile = new UserProfileModelDTO()
                {
                    FirstName = "Gora",
                    Address = new AddressModelDTO()
                    {
                        StreetName = "Tyagyk"
                    }
                },
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await accountService.UpdateUserData(dto));
            Assert.AreEqual(exeption.Message, "User not exist!");
        }

        [Test]
        public async Task ChangeEmail()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var user = await TestHelper.ApplicationContext.Users.FirstOrDefaultAsync(x => x.UserName == "admin@admin.admin");
            var dto = new ChangeEmailDTO()
            {
                UserId = user.Id,
                Email = "hello@gmail.com"
            };

            var newEmail = await accountService.ChangeEmail(dto);

            Assert.IsNotNull(newEmail);
            Assert.AreEqual(newEmail.Email, user.Email);
        }

        [Test]
        public async Task ChangeEmailExceptionTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var dto = new ChangeEmailDTO()
            {
                UserId = Guid.NewGuid(),
                Email = "hello@gmail.com"
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await accountService.ChangeEmail(dto));
            Assert.AreEqual(exeption.Message, "User not exist!");
        }

        [Test]
        public async Task UpdateUserPasswordTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var user = await TestHelper.ApplicationContext.Users.FirstOrDefaultAsync(x => x.UserName == "admin@admin.admin");
            var dto = new UpdateUserPasswordDTO()
            {
                UserId = user.Id,
                Password = user.PasswordHash,
                NewPassword = "qwerty1234",
            };

            var newPassword = await accountService.UpdateUserPassword(dto);

            Assert.IsTrue(newPassword);
        }

        [Test]
        public async Task UpdateUserPasswordExceptionTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var dto = new UpdateUserPasswordDTO()
            {
                UserId = Guid.NewGuid(),
                Password = "hello",
                NewPassword = "qwerty1234",
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await accountService.UpdateUserPassword(dto));
            Assert.AreEqual(exeption.Message, "User not exist!");
        }

        [Test]
        public async Task GetAllUsersTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var users = await accountService.GetAllUsers();
            var usersFromContext = await TestHelper.ApplicationContext.Users.CountAsync();
            Assert.IsNotNull(users);
            Assert.AreEqual(usersFromContext, users.Count());
        }

        [Test]
        public async Task GetUserByIdTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var user = await TestHelper.ApplicationContext.Users.FirstOrDefaultAsync(x => x.UserName == "admin@admin.admin");
            var dto = new GetUserByIdDTO()
            {
                UserId = user.Id,
            };

            var foudUser = await accountService.GetUserById(dto);
            
            Assert.IsNotNull(foudUser);
            Assert.AreEqual(foudUser.UserName, user.UserName);
        }

        [Test]
        public async Task GetUserByUserNameTest()
        {
            var accountService = new AccountService(TestHelper.ApplicationContext, TestHelper.SignInManagerMock.Object, TestHelper.TestMapper, _logger);
            var dto = new GetUserByUserNameDTO()
            {
                UserName = "admin@admin.admin",
            };

            var foudUser = await accountService.GetUserByUserName(dto);
            var userFromContext = await TestHelper.ApplicationContext.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName);

            Assert.IsNotNull(foudUser);
            Assert.AreEqual(foudUser.UserName, userFromContext.UserName);
        }
    }
}
