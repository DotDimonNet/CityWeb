using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.Entities
{
    public static class ErrorModel
    {
        public static string AddNewsItemError { get; set; } = "You can't create News Item. Item already exists";
        public static string AddNewsItemErrorService { get; set; } = "You can't create News Item. Section of News doesn't exist";
        public static string AddNewsServiceError { get; set; } = "You can't create Section of News. News Section is already exists";
        public static string DeleteNewsItemError { get; set; } = "News Item is not exists";
        public static string DeleteNewsServiceError { get; set; } = "News Service is not exists";
        public static string UpdateNewsItemError { get; set; } = "News Item is not exists";
        public static string UpadateNewsServiceError { get; set; } = "News Service is not exists";

    }
}
