using CityWeb.Domain.Entities;
using CityWeb.Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public static class TestHelper
    {
        public static ApplicationContext ApplicationContext { get; set; }

        public static Mock<UserManager<ApplicationUserModel>> UserManagerMock;
        public static Mock<SignInManager<ApplicationUserModel>> SignInManagerMock;
        public static Mock<RoleManager<ApplicationUserRole>> RoleManagerMock;

        public static async Task SetupDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            ApplicationContext = new ApplicationContext(options);

            await SetupManagementMocks();

            var dbInitializer = new DbInitializer(ApplicationContext, UserManagerMock.Object, RoleManagerMock.Object);
            await dbInitializer.Initialize();
            await GenerateData();
        }

        private static async Task SetupManagementMocks()
        {
            var user = new ApplicationUserModel
            {
                UserName = "admin@admin.admin",
                Email = "admin@admin.admin",
                EmailConfirmed = true,
                Profile = new UserProfileModel
                {
                    Gender = "male"
                }
            };

            var store = new Mock<IUserStore<ApplicationUserModel>>();
            UserManagerMock = new Mock<UserManager<ApplicationUserModel>>(store.Object, null, null, null, null, null, null, null, null);
            
            UserManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUserModel>(), It.IsAny<string>()))
                .Callback((ApplicationUserModel userModel, string password) =>
                {
                    ApplicationContext.Users.Add(userModel);
                    ApplicationContext.SaveChanges();
                }).ReturnsAsync(IdentityResult.Success).Verifiable();

            UserManagerMock.Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(await ApplicationContext.Users.FirstOrDefaultAsync()).Verifiable();

            UserManagerMock.Setup(x => x.AddToRoleAsync(It.IsAny<ApplicationUserModel>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success).Verifiable();

            var storeRoles = new Mock<IRoleStore<ApplicationUserRole>>();
            RoleManagerMock = new Mock<RoleManager<ApplicationUserRole>>(storeRoles.Object, null, null, null, null);
            
            RoleManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUserRole>()))
                .ReturnsAsync(IdentityResult.Success).Verifiable();    
        }

        private static async Task GenerateData()
        {
            var service = new ServiceModel();
            var carSharings = new List<CarSharingModel>();
            for (int i = 0; i < 10; i++)
            {
                var carSharing = new CarSharingModel()
                {
                    Title = $"CarSharing{i+1}",
                    Description = $"Default descriotion {i}",
                    Payment = new PaymentModel(),
                    
                };

                carSharings.Add(carSharing);
            }
            await ApplicationContext.CarSharings.AddRangeAsync(carSharings);
            await ApplicationContext.SaveChangesAsync();
        }
    }
}