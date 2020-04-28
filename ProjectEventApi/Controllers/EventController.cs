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
            [FromQuery]int pageSize = 6)
        {
            var itemsCount = await _context.EventItems.LongCountAsync();
            var items = await _context.EventItems
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = changePictureUrl(items);

            var model = new PaginatedItemViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = items
            };
            return Ok(model);
        }

        [HttpGet]
        [Route("[action]/type/{eventTypeId}/location/{eventLocationId}")]
        public async Task<IActionResult> Items(
            int? eventTypeId,
            int? eventLocationId,
            [FromQuery]int pageIndex = 0,
            [FromQuery]int pageSize = 6)
        {
            var root = (IQueryable<EventItem>)_context.EventItems;
            if (eventTypeId.HasValue)
            {
                root = root.Where(c => c.EventTypeId == eventTypeId);
            }
            if (eventLocationId.HasValue)
            {
                root = root.Where(c => c.EventLocationId == eventLocationId);
            }

            var itemsCount = await root.LongCountAsync();
            var items = await root
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = changePictureUrl(items);

            var model = new PaginatedItemViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = items
            };
            return Ok(model);
        }

        private List<EventItem> changePictureUrl(List<EventItem> items)

        {
            items.ForEach(
                c => c.PictureUrl = c.PictureUrl.Replace("http://externaleventbaseurltobereplaced", _config["ExternalEventBaseUrl"]));
            return items;

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var items = await _context.EventTypes.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var items = await _context.EventLocations.ToListAsync();
            return Ok(items);
        }
    }
}