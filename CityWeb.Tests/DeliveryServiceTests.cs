using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using CityWeb.Infrastructure.Service;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeb.Tests
{
    public class DeliveryServiceTests
    {
        [SetUp]
        public async Task Setup()
        {
            await TestHelper.SetupDbContext();
        }

        [Test]
        public async Task CreateDeliveryCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new CreateDeliveryModelDTO()
            {
                Title = "Delivery Company",
                Description = "Default description"
            };

            var delivery = await deliveryService.CreateDeliveryCompany(dto);
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Title == delivery.Title);

            Assert.IsNotNull(delivery);
            Assert.AreEqual(delivery.Description, deliveryFromContext.Description);
            Assert.AreEqual(delivery.Title, deliveryFromContext.Title);
        }

        [Test]
        public async Task UpdateDeliveryCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new UpdateDeliveryModelDTO()
            {
                Title = "DeliveryCompany2",
                Description = "Super quick",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Value = 10.00,
                Tax = 0.00,
                VAT = 2.00,
            };
            var delivery = await deliveryService.UpdateDeliveryCompany(dto);
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Title == dto.Title);

            Assert.IsNotNull(delivery);
            Assert.AreEqual(delivery.Description, deliveryFromContext.Description);
            Assert.AreEqual(delivery.StartTime, deliveryFromContext.WorkSchedule.StartTime);
            Assert.AreEqual(delivery.EndTime, deliveryFromContext.WorkSchedule.EndTime);
            Assert.AreEqual(delivery.Value, deliveryFromContext.DeliveryPrice.Value);
        }

        [Test]
        public async Task UpdateDeliveryCompanyExeptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new UpdateDeliveryModelDTO()
            {
                Title = "DeliveryCompany17",
                Value = 10.00,
                Tax = 0.00,
                VAT = 2.00,
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.UpdateDeliveryCompany(dto));
            Assert.AreEqual(exeption.Message, "Company was not created!");
        }

            [Test]
        public async Task CreateMenuTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new ProductModelDTO()
            {
                Title = "DeliveryCompany2",
                ProductName = "Product",
                ProductType = ProductType.AlcoholicDrinks,
                ProductImage = "img",
                Value = 200.00,
                Tax = 10.00,
                VAT = 10.00,
            };

            var product = await deliveryService.CreateMenu(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.ProductName == product.ProductName);

            Assert.IsNotNull(product);
            Assert.AreEqual(product.ProductName, productFromContext.ProductName);
            Assert.AreEqual(product.ProductType.Name, productFromContext.ProductType.Name);
            Assert.AreEqual(product.ProductImage, productFromContext.ProductImage);
            Assert.AreEqual(product.VAT, productFromContext.ProductPrice.VAT);
            Assert.AreEqual(product.Tax, productFromContext.ProductPrice.Tax);
            Assert.AreEqual(product.Value, productFromContext.ProductPrice.Value);
        }

        [Test]
        public async Task CreateMenuTestExeptionOneTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new ProductModelDTO()
            {
                Title = "DeliveryCompany22",
                ProductName = "Product",
                ProductType = ProductType.AlcoholicDrinks,
                ProductImage = "img",
                Value = 200.00,
                Tax = 10.00,
                VAT = 10.00,
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.CreateMenu(dto));
            Assert.AreEqual(exeption.Message, "Company was not created!");
        }

        [Test]
        public async Task CreateMenuTestExeptionTwoTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new ProductModelDTO()
            {
                Title = "DeliveryCompany2",
                ProductName = "Product2",
                ProductType = ProductType.AlcoholicDrinks,
                ProductImage = "img",
                Value = 200.00,
                Tax = 10.00,
                VAT = 10.00,
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.CreateMenu(dto));
            Assert.AreEqual(exeption.Message, "Product was already created!");
        }

        [Test]
        public async Task UpdateProductTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new ProductModelDTO()
            {
                Title = "DeliveryCompany1",
                ProductName = "Product1",
                Value = 300.00,
            };

            var product = await deliveryService.UpdateProduct(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.ProductName == product.ProductName);
            Assert.IsNotNull(product);
            Assert.AreEqual(product.Value, productFromContext.ProductPrice.Value);
        }

        [Test]
        public async Task UpdateProductExeptionOneTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new ProductModelDTO()
            {
                Title = "DeliveryCompany15",
                ProductName = "Product1",
                Value = 300.00,
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.UpdateProduct(dto));
            Assert.AreEqual(exeption.Message, "Company was not created!");
        }

        [Test]
        public async Task UpdateProductExeptionTwoTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new ProductModelDTO()
            {
                Title = "DeliveryCompany5",
                ProductName = "Product6",
                Value = 300.00,
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.UpdateProduct(dto));
            Assert.AreEqual(exeption.Message, "Product was not created!");
        }

        [Test]
        public async Task DeleteDeliveryCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new DeleteCompanyDTO()
            {
                Title = "DeliveryCompany6"
            };

            await deliveryService.DeleteDeliveryCompany(dto);
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Title == dto.Title);
            Assert.IsNull(deliveryFromContext);    
        }

        [Test]
        public async Task DeleteDeliveryCompanyExeptionTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new DeleteCompanyDTO()
            {
                Title = "DeliveryCompany666"
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.DeleteDeliveryCompany(dto));
            Assert.AreEqual(exeption.Message, "Company does not exist!");
        }

            [Test]
        public async Task DeleteProductTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new DeleteProductDTO()
            {
                Title = "DeliveryCompany6",
                ProductName = "Product6",
            };

            await deliveryService.DeleteProduct(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.ProductName == dto.ProductName);
            Assert.IsNull(productFromContext);
        }

        [Test]
        public async Task DeleteProductExeptionOneTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new DeleteProductDTO()
            {
                Title = "DeliveryCompany66",
                ProductName = "Product6",
            };
            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.DeleteProduct(dto));
            Assert.AreEqual(exeption.Message, "Company does not exist!");
        }

        [Test]
        public async Task DeleteProductExeptionTwoTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new DeleteProductDTO()
            {
                Title = "DeliveryCompany6",
                ProductName = "Product66",
            };
            var exeption = Assert.ThrowsAsync<Exception>(async () => await deliveryService.DeleteProduct(dto));
            Assert.AreEqual(exeption.Message, "Product does not exist!");
        }

        [Test]
        public async Task ShowWorkingCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new DeliveryCompanySheduleDTO()
            {
                WorkTime = DateTime.Now,
            };

            deliveryService.ShowWorkingCompany(dto);
            var deliveryFromContext = TestHelper.ApplicationContext.Deliveries.Where(x => x.WorkSchedule.StartTime < dto.WorkTime && x.WorkSchedule.EndTime > dto.WorkTime).Count();
            Assert.IsTrue(deliveryFromContext == 10);
        }

        [Test]

        public async Task SelectDeliveryCompanyTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new SelectDeliveryModelDTO()
            {
                Title = "DeliveryCompany6",
            };

            var productType = deliveryService.SelectDeliveryCompany(dto);
            var delivery = TestHelper.ApplicationContext.Deliveries.FirstOrDefault(x => x.Title == dto.Title);
            var productTypeFromContext = delivery.Products.Select(x => x.ProductType.Name);

            Assert.IsNotNull(productType);
            Assert.AreEqual(productType.Result, productTypeFromContext);
        }

        [Test]
        public async Task GetProductsByTypeTest()
        {
            var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
            var dto = new ProductByTypeDTO()
            {
                ProductName = "Product1",
                TypeName = "AlcoholicDrinks"
            };

            var product = deliveryService.GetProductsByType(dto);
            var productFromContext = TestHelper.ApplicationContext.Products.FirstOrDefault(x => x.ProductName == dto.ProductName && x.ProductType.Name == dto.TypeName);
            Assert.IsNotNull(product);
            foreach (var item in product)
            {
                Assert.AreEqual(item.ProductName, productFromContext.ProductName);
                Assert.AreEqual(item.ProductImage, productFromContext.ProductImage);
                Assert.AreEqual(item.Value, productFromContext.ProductPrice.Value);
            }
        }

        //[Test]
        //public async Task CheckoutBusketTest()
        //{
        //    var deliveryService = new DeliveryService(TestHelper.ApplicationContext);
        //    var dto = new BusketModelDTO()
        //    {
        //        Busket =
        //        {
        //            new BusketItemModelDTO()
        //            {
        //                ProductId = Guid.NewGuid(),
        //                Quantity = 5,
        //            }
        //        },
        //        Address = new AddressModel()
        //        {
        //            StreetName = "Vatytina",
        //            HouseNumber = "58",
        //            ApartmentNumber = "101",
        //        },
        //       UserName = "Volodya"
        //    };

        //    var delivery = deliveryService.CheckoutBusket(dto);
            
        //}



    }
}