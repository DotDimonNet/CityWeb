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
        public Task<NewsItemModel> GetItem(GetNewsItemDTO getItem);
        public Task<IEnumerable<string>> GetNewsOfService(GetServiceDTO getNews);
        public Task<NewsModel> AddNewsService(AddNewsServiceDTO addService);
        public Task<NewsItemModel> AddNews(AddNewsItemDTO addNewsItem, AddNewsServiceDTO addNewsService);
        public Task<NewsModel> UpdateNewsService(UpdateNewsServiceDTO updateService);
        public Task<NewsItemModel> UpdateNewsItem(UpdateNewsItemDTO updateNews, UpdateNewsServiceDTO updateService);
        public Task<bool> DeleteNewsService(DeleteNewsServiceDTO deleteService);
        public Task<bool> DeleteNews(DeleteNewsItemDTO deleteNews, DeleteNewsServiceDTO deleteNewsService);
    }
}
