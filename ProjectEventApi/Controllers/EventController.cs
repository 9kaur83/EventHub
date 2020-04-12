using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectEventApi.Data;
using ProjectEventApi.Domain;
using ProjectEventApi.ViewModel;

namespace ProjectEventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public EventController(EventContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageIndex = 0,
            [FromQuery]int pageSize = 2)
        {
            var itemsCount = await _context.EventItems.LongCountAsync();

           var items = await _context.EventItems.Skip(pageIndex * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemViewModel<EventItem>
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                count = itemsCount,
                Data = items
            };
            return Ok(model);
        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(
                e => e.PictureUrl =
                e.PictureUrl.Replace("http://externaleventbaseurltobereplaced",
                     _config["ExternalEventBaseUrl"])
                 );
            return items;
        }
    }
}