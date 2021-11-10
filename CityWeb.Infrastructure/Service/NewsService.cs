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
using AutoMapper;
using Microsoft.Extensions.Logging;
using CityWeb.Domain.Enums;

namespace CityWeb.Infrastructure.Service
{
    public class NewsService : INewsService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountService> _logger;
        
        public NewsService(ApplicationContext context, IMapper mapper, ILogger<AccountService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<NewsItemModelDTO> AddNewsItem(AddNewsItemDTO addData)
        {
            try
            {
                var newsService = await _context.News.FirstOrDefaultAsync(x => Enum.Parse<NewsType>(addData.Type) == x.Type);
                if (newsService != null)
                {
                    var newsItem = await _context.NewsItems.FirstOrDefaultAsync(x => x.Title == addData.Title);
                    if (newsItem == null)
                    {
                        newsItem = _mapper.Map<AddNewsItemDTO, NewsItemModel>(addData);
                        await _context.NewsItems.AddAsync(newsItem);
                        newsService.NewsItems.Add(newsItem);
                        await _context.SaveChangesAsync();
                        return _mapper.Map<NewsItemModel, NewsItemModelDTO>(newsItem);
                    }
                    else
                    {
                        _logger.LogError(ErrorModel.AddNewsItemError);
                        throw new Exception(ErrorModel.AddNewsItemError);
                    }

                }
                else
                {
                    _logger.LogError(ErrorModel.AddNewsItemErrorService);
                    throw new Exception(ErrorModel.AddNewsItemErrorService);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<NewsModelDTO> AddNewsService(AddNewsModelDTO addService)
        
        {
            try
            {
                var newsService = await _context.News.FirstOrDefaultAsync(x => Enum.Parse<NewsType>(addService.Type) == x.Type);
                if (newsService == null)
                {
                    newsService = _mapper.Map<AddNewsModelDTO, NewsModel>(addService);
                    await _context.News.AddAsync(newsService);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<NewsModel, NewsModelDTO>(newsService);
                }
                else
                {
                    _logger.LogError(ErrorModel.AddNewsServiceError);
                    throw new Exception(ErrorModel.AddNewsServiceError);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
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
                throw new Exception(ErrorModel.DeleteNewsItemError);
            }

        }

        public async Task<bool> DeleteNewsService(DeleteNewsModelDTO deleteService)
        {
            var service = await _context.News.FirstOrDefaultAsync(x => Enum.Parse<NewsType>(deleteService.Type) == x.Type);
            if (service != null)
            {
                _context.Remove(service);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception(ErrorModel.DeleteNewsServiceError);
            }
        }

        //public async Task<IEnumerable<string>> GetNewsOfService(GetServiceDTO getNews)
        //{

        //}

        //public async Task<NewsItemModelDTO> GetItem(GetNewsItemDTO getItem)
        //{

        //}

        public async Task<NewsItemModelDTO> UpdateNewsItem(UpdateNewsItemDTO updateNews)
        {
            try
            {
                var newsItem = await _context.NewsItems.FirstOrDefaultAsync(x => x.Title == updateNews.NewsItemTitle);
                if (newsItem != null)
                {
                    _mapper.Map<UpdateNewsItemDTO, NewsItemModel>(updateNews, newsItem);
                    _context.NewsItems.Update(newsItem);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<NewsItemModel, NewsItemModelDTO>(newsItem);
                }
                else
                {
                    _logger.LogError(ErrorModel.UpdateNewsItemError);
                    throw new Exception(ErrorModel.UpdateNewsItemError);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<NewsModelDTO> UpdateNewsService(UpdateNewsModelDTO updateService)
        {
            try
            {
                var newsService = await _context.News.FirstOrDefaultAsync(x => Enum.Parse<NewsType>(updateService.Type) == x.Type);
                if (newsService != null)
                {
                    _mapper.Map<UpdateNewsModelDTO, NewsModel>(updateService, newsService);
                    _context.News.Update(newsService);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<NewsModel, NewsModelDTO>(newsService);
                }
                else
                {
                    _logger.LogError(ErrorModel.UpadateNewsServiceError);
                    throw new Exception(ErrorModel.UpadateNewsServiceError);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
            
        }


    }
}

