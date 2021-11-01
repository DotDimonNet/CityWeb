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
        public Task<IEnumerable<string>> GetService(GetServiceDTO getService);
        public IEnumerable<string> GetNewsOfService(IEnumerable<string> getNews);
        public Task<NewsModel> AddNewsService(AddNewsServiceDTO addService);
        public Task<NewsItemModel> AddNews(AddNewsItemDTO addNewsItem, AddNewsServiceDTO addNewsService);
        public Task<NewsModel> UpdateNewsService(UpdateNewsServiceDTO updateService);
        public IEnumerable<string> UpdateNews(IEnumerable<string> updateNews);
        public void DeleteNewsService(DeleteNewsServiceDTO deleteService);
        public Task<bool> DeleteNews(DeleteNewsItemDTO deleteNews, DeleteNewsServiceDTO deleteNewsService);
    }
}
