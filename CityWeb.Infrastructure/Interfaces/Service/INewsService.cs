using CityWeb.Domain.DTO.NewsDTO;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Interfaces.Service
{
    public interface INewsService
    {
        //public Task<NewsItemModelDTO> GetItem(GetNewsItemDTO getItem);
        //public Task<IEnumerable<string>> GetNewsOfService(GetServiceDTO getNews);
        public Task<NewsModelDTO> AddNewsService(AddNewsModelDTO addService);
        public Task<NewsItemModelDTO> AddNews(AddNewsItemDTO addNewsItem);
        //public Task<NewsModelDTO> UpdateNewsService(UpdateNewsModelDTO updateService);
        //public Task<NewsItemModelDTO> UpdateNewsItem(UpdateNewsItemDTO updateNews);
        public Task<bool> DeleteNewsService(DeleteNewsModelDTO deleteService);
        public Task<bool> DeleteNews(DeleteNewsItemDTO deleteNews);
    }
}
