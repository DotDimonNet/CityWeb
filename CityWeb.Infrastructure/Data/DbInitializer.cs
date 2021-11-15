using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CityWeb.Domain.Entities;
using CityWeb.Infrastructure.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CityWeb.Infrastucture.Data
{
    public class DbInitializer
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly RoleManager<ApplicationUserRole> _roleManager;

        public DbInitializer(
            ApplicationContext context,
            UserManager<ApplicationUserModel> userManager,
            RoleManager<ApplicationUserRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            IdentityResult result;

            InitialData.SetupEnums(_context);
            InitialData.SetupData(_context);

            if (!_context.Roles.Any(r => r.Name == Roles.Admin))
            {
                //Create the Administartor Role
                result = await _roleManager.CreateAsync(new ApplicationUserRole(Roles.Admin));
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));
            }

            if (!_context.Roles.Any(r => r.Name == Roles.ContentManager))
            {
                //Create the TasteExpert Role
                result = await _roleManager.CreateAsync(new ApplicationUserRole(Roles.ContentManager));
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));
            }

            if (!_context.Roles.Any(r => r.Name == Roles.User))
            {
                //Create the User Role
                result = await _roleManager.CreateAsync(new ApplicationUserRole(Roles.User));
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));
            }

            if (!_context.Roles.Any(r => r.Name == Roles.Guest))
            {
                //Create the User Role
                result = await _roleManager.CreateAsync(new ApplicationUserRole(Roles.Guest));
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));
            }

            ApplicationUserModel user = null;

            if (!_context.Users.Any(r => r.UserName == "admin@admin.admin"))
            {
                user = new ApplicationUserModel { 
                    UserName = "admin@admin.admin", 
                    Email = "admin@admin.admin", 
                    EmailConfirmed = true, 
                    Profile = new UserProfileModel
                    {
                        Address = new AddressModel()
                        {
                            ApartmentNumber = "6",
                            StreetName = "Soborna st.",
                            HouseNumber = "1",
                        }
                    }
                };
                string password = "P@ssw0rd";

                result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));

                result = await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user.UserName), Roles.Admin);
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));

                result = await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user.UserName), Roles.ContentManager);
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));

                result = await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user.UserName), Roles.User);
                if (!result.Succeeded) throw new DbInitializationException(result.Errors.Select(x => x.Description).Aggregate((x, y) => $"{x} {y}"));

                _context.SaveChanges();
            }
        }
    }

    [Serializable]
    public class DbInitializationException : Exception
    {
        public DbInitializationException()
        {
        }

        public DbInitializationException(string message) : base(message)
        {
        }

        public DbInitializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbInitializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
