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

namespace CityWeb.Infrastructure.Service
{
    public class NewsService : INewsService
    {
        private readonly ApplicationContext _context;

        public NewsService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<NewsItemModel> AddNews(AddNewsItemDTO addNewsItem, AddNewsServiceDTO addNewsService)
        {
            var service = await _context.News.FirstOrDefaultAsync(x => x.Title == addNewsService.ServiceTitle && x.Type == addNewsService.ServiceType);
            if (service != null)
            {
                var newsItem = await _context.NewsItems.FirstOrDefaultAsync(x => x.Title == addNewsItem.Title);
                if (newsItem == null)
                {
                    var addItem = new NewsItemModel()
                    {
                        Title = addNewsItem.Title,
                        Description = addNewsItem.Description
                    };
                    await _context.NewsItems.AddAsync(addItem);
                    await _context.SaveChangesAsync();
                    return addItem;
                }
                else
                {
                    throw new Exception("News Item was already created");
                }
            }
            else
            {
                throw new Exception("News Service is not created");
            }
        }

        public async Task<NewsModel> AddNewsService(AddNewsServiceDTO addService)
        {
            var service = await _context.News.FirstOrDefaultAsync(x => x.Title == addService.ServiceTitle);
            if(service == null)
            {
                var addNewsService = new NewsModel()
                {
                    Title = addService.ServiceTitle,
                    Description = addService.Description,
                    Type = addService.ServiceType
                };
                await _context.News.AddAsync(addNewsService);
                await _context.SaveChangesAsync();
                return addNewsService;
            }
            else
            {
                throw new Exception("News Service was already created");
            }
        }

        public async Task<bool> DeleteNews(DeleteNewsItemDTO deleteNews, DeleteNewsServiceDTO deleteNewsService )
        {
            var service = await _context.News.FirstOrDefaultAsync(x => x.Title == deleteNewsService.ServiceTitle && x.Type == deleteNewsService.Type);
            if (service != null)
            {
                var deleteNewsItem = await _context.NewsItems.FirstOrDefaultAsync(x => x.Title == deleteNews.NewsItemTitle);
                if (deleteNewsItem != null)
                {
                    _context.Remove(service);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new Exception("News Item is not exists");
                }
            }
            else
            {
                throw new Exception("News Service is not exists");
            }
        }

        public async Task<bool> DeleteNewsService(DeleteNewsServiceDTO deleteService)
        {
            var service =  await _context.News.FirstOrDefaultAsync(x => x.Title == deleteService.ServiceTitle);
            if (service != null)
            {
                _context.Remove(service);
                await _context.SaveChangesAsync();
                _context.Update(service);
                return true;
            }
            else
            {
                throw new Exception("News Service is not exists");
            }
        }

        public IEnumerable<string> GetNewsOfService(IEnumerable<string> getNews)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetService(GetServiceDTO getService)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> UpdateNews(IEnumerable<string> updateNews)
        {
            throw new NotImplementedException();
        }

        public async Task<NewsModel> UpdateNewsService(UpdateNewsServiceDTO updateService)
        {
            var service = await _context.News.FirstOrDefaultAsync(x => x.Title == updateService.ServiceTitle);
            if (service != null)
            {
                var updateNewsService = new NewsModel()
                {
                    Title = updateService.ServiceTitle,
                    Description = updateService.Description
                    
                };
                _context.Update(service);
                await _context.SaveChangesAsync();
                return updateNewsService;
            }
            else
            {
                throw new Exception("News Service is not exists");
            }
        }

        
    }
}
