using CityWeb.Domain.DTO.NewsDTO;
using CityWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Infrastructure.Extentions
{
    public static class DTONewsExtension
    {
        //public static NewsItemModel ToNewsItemModelDTO(this GetNewsItemDTO newsModel)
        //{
        //    return new NewsItemModel()
        //    {
        //        Title = newsModel.Title
        //    };
        //}
        public static NewsItemModel ToNewsItemModel(this AddNewsItemDTO addData)
        {
            return new NewsItemModel()
            {
                Title = addData.Title,
                Description = addData.Description
            };

        }
        public static NewsModel ToNewsModelDTO(this AddNewsModelDTO addData)
        {
            return new NewsModel()
            {
                Title = addData.ServiceTitle,
                Description = addData.Description
            };
        }

        public static NewsItemModelDTO ToNewsItemModelDTO(this NewsItemModel itemModel)
        {
            return new NewsItemModelDTO()
            {
                Title = itemModel.Title,
                Description = itemModel.Description
            };

        }
        public static NewsModelDTO ToNewsModelDTO(this NewsModel newsModel)
        {
            return new NewsModelDTO()
            {
                ServiceTitle = newsModel.Title,
                Description = newsModel.Description
            };

        }
    }
}
