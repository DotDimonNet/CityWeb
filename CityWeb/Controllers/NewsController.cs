using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityWeb.Domain.DTO.NewsDTO;
using CityWeb.Infrastructure.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace CityWeb.Controllers
{
    [ApiController]
    [Route("api/news")]

    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPut("add")]
        public async Task<IActionResult> AddNewsService([FromBody] AddNewsModelDTO request)
        {
            try
            {
                var entertainment = await _newsService.AddNewsService(request);
                return Json(entertainment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("services/add")]
        public async Task<IActionResult> AddNews([FromBody] AddNewsItemDTO request)
        {
            try
            {
                var entertainment = await _newsService.AddNews(request);
                return Json(entertainment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost("update")]
        //public async Task<IActionResult> UpdateNewsService([FromBody] UpdateNewsModelDTO request)
        //{
        //    try
        //    {
        //        var entertainment = await _newsService.UpdateNewsService(request);
        //        return Json(entertainment);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPost("services/add")]
        //public async Task<IActionResult> UpdateNewsItem([FromBody] UpdateNewsItemDTO request)
        //{
        //    try
        //    {
        //        var entertainment = await _newsService.UpdateNewsItem(request);
        //        return Json(entertainment);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteNewsService([FromBody] DeleteNewsModelDTO request)
        {
            try
            {
                var entertainment = await _newsService.DeleteNewsService(request);
                return Ok(entertainment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("services/delete")]
        public async Task<IActionResult> DeleteNews([FromBody] DeleteNewsItemDTO request)
        {
            try
            {
                var entertainment = await _newsService.DeleteNews(request);
                return Ok(entertainment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

