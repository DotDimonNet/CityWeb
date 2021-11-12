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


        public static string UpdateEntertainmentModelError { get; set; } = "You can't update Entertainment. Entertainment doesn't exist!";
        public static string UpdateEventModelError { get; set; } = "You can't update Event. Event doesn't exist!";
        public static string UpdateEventModelEntertainmentError { get; set; } = "You can't update Event. Entrertainment doesn't exist!";
        public static string DeleteEntertainmentModelError { get; set; } = "You can't delete Entertainment. Entertainment doesn't exist!";
        public static string DeleteEventModel { get; set; } = "You can't delete Event. Event doesn't exist!";
        public static string AddEntertainmentModelError { get; set; } = "You can't create Entertainment. Entertainment already exists!";
        public static string AddEventModelError { get; set; } = "You can't create Event. Event already exists!";
        public static string AddEventModelEntertainmentError { get; set; } = "You can't create Event. Entertainment doesn't exist!";
        public static string GetEventsFromEntertainmentError { get; set; } = "You can't get Events. Entertainment doesn't exist!";
        public static string GetEventFromEventsError { get; set; } = "You can't get Event. Event doesn't exist!";



    }
}
