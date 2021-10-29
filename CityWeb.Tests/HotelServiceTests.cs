using CityWeb.Domain.DTO;
using CityWeb.Domain.DTO.HotelDTO;
using CityWeb.Infrastructure.Service;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class HotelServiceTests
    {
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
        }
    }
}
