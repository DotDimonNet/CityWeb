using CityWeb.Domain.DTO.NewsDTO;
using CityWeb.Domain.Entities;
using CityWeb.Infrastructure.Interfaces.Service;
using CityWeb.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityWeb.Infrastructure.Extentions;

namespace CityWeb.Infrastructure.Service
{
    public class NewsService : INewsService
    {
        private readonly ApplicationContext _context;

        public NewsService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<NewsItemModelDTO> AddNews(AddNewsItemDTO addData)
        {
            var newsItem = await _context.NewsItems.FirstOrDefaultAsync(x => x.Title == addData.Title);
            if (newsItem == null)
            {
                var addNewsItem = addData.ToNewsItemModel();
                var model = await _context.NewsItems.AddAsync(addNewsItem);
                await _context.SaveChangesAsync();
                return model.Entity.ToNewsItemModelDTO();
            }
            else
            {
                throw new Exception("News Item was already created");
            }
        }

        public async Task<NewsModelDTO> AddNewsService(AddNewsModelDTO addService)
        {
            var service = await _context.News.FirstOrDefaultAsync(x => x.Title == addService.ServiceTitle);
            if (service == null)
            {
                var addNews = addService.ToNewsModelDTO();
                var model = await _context.News.AddAsync(addNews);
                await _context.SaveChangesAsync();
                return model.Entity.ToNewsModelDTO();
            }
            else
            {
                throw new Exception("News Service was already created");
            }
        }

        public async Task<bool> DeleteNews(DeleteNewsItemDTO deleteNews)
        {
            var deleteNewsItem = await _context.NewsItems.FirstOrDefaultAsync(x => x.Title == deleteNews.NewsItemTitle);
            if (deleteNewsItem != null)
            {
                _context.Remove(deleteNews);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("News Item is not exists");
            }

        }

        public async Task<bool> DeleteNewsService(DeleteNewsModelDTO deleteService)
        {
            var service = await _context.News.FirstOrDefaultAsync(x => x.Title == deleteService.ServiceTitle);
            if (service != null)
            {
                _context.Remove(service);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("News Service is not exists");
            }
        }

        //public async Task<IEnumerable<string>> GetNewsOfService(GetServiceDTO getNews)
        //{

        //}

        //public async Task<NewsItemModelDTO> GetItem(GetNewsItemDTO getItem)
        //{

        //}

        //    public async Task<NewsItemModelDTO> UpdateNewsItem(UpdateNewsItemDTO updateNews)
        //    {
        //        var newsItem = await _context.NewsItems.FirstOrDefaultAsync(x => x.Title == updateNews.NewsItemTitle);
        //        if (newsItem != null)
        //        {
        //            var model = _context.NewsItems.Update(newsItem.UpdateFromDTO(updateNews));
        //            await _context.SaveChangesAsync();
        //            return model.Entity.ToNewsItemModelDTO();
        //        }
        //        else
        //        {
        //            throw new Exception("News Item is not exists");
        //        }
        //    }

        //    public async Task<NewsModelDTO> UpdateNewsService(UpdateNewsModelDTO updateService)
        //    {
        //        var newsService = await _context.News.FirstOrDefaultAsync(x => x.Title == updateService.ServiceTitle);
        //        if (newsService != null)
        //        {
        //            var model = _context.News.Update(newsService.UpdateFromDTO(updateService));
        //            await _context.SaveChangesAsync();
        //            return model.Entity.ToNewsModelDTO();
        //        }
        //        else
        //        {
        //            throw new Exception("News Service is not exists");
        //        }
        //    }


        //}
    }
}

