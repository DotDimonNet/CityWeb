﻿using CityWeb.Domain.DTO;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces.Service
{
    public interface IDeliveryService
    {
        public Task<DeliveryModelDTO> CreateDeliveryCompany(CreateDeliveryModelDTO deliveryModel);
        public Task<ICollection<DeliveryModelDTO>> GetAllDelivery(int skip = 0, int take = 10);
        public Task<DeliveryModelDTO> UpdateDeliveryCompany(UpdateDeliveryModelDTO deliveryModel);
        public Task<ProductModelDTO> UpdateProduct(UpdateProductModelDTO updateProduct);
        public Task<ProductModelDTO> CreateProduct(CreateProductModelDTO createProductDTO);
        public Task<bool> DeleteDeliveryCompany(DeleteCompanyDTO dtoModel);
        public Task<bool> DeleteProduct(DeleteProductDTO dtoModel);
        public Task<DeliveryModelDTO> GetDeliveryById(DeliveryIdDTO deliveryIdDTO);
        public Task<ICollection<ProductModelDTO>> GetAllProductByDeliveryId(DeliveryIdDTO deliveryName);
        public Task<ICollection<ProductModelDTO>> GetAllProductByPriceFilter(ProductPriceFilterDTO priceFilter, int skip = 0, int take = 10);
        // Methods for steps
        public IEnumerable<SelectDeliveryModelDTO> ShowWorkingCompany(DeliveryCompanySheduleDTO companyShedule);
        public Task<ICollection<string>> SelectDeliveryCompany(SelectDeliveryModelDTO dtoModel);
        public Task<IEnumerable<ProductModelDTO>> GetProductsByType(ProductByTypeDTO dtoModel);
        public Task<PaymentModelDTO> CheckoutBusket(BusketModelDTO busketModelDTO);
        
    }
}
