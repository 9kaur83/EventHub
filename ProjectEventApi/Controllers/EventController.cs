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
           // [FromQuery]string location = "",
            //[FromQuery]int eventTypeId = -1,
            [FromQuery]int pageIndex = 0,
            [FromQuery]int pageSize = 2)
        {
            
            /* code for following cases:
                - Both location and eventTypeId input provided.
                - Or only location provided
                - Or only eventTypeId provided
                - or Both location and eventTypeId not provided.
           */
           /*
            List<EventItem> items;
            List<EventItem> totalItems;

            if (string.IsNullOrEmpty(location) && eventTypeId == -1)
            {
                totalItems = await _context.EventItems.ToListAsync();
            }
            else if (string.IsNullOrEmpty(location) && eventTypeId != -1)
            {
                totalItems = await _context.EventItems
                         .Where(i => i.EventTypeId == eventTypeId).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(location) && eventTypeId == -1)
            {
                totalItems = await _context.EventItems
                          .Where(i => i.Location == location).ToListAsync();
            }
            else
            {
                totalItems = await _context.EventItems
                         .Where(i => i.Location == location && i.EventTypeId == eventTypeId)
                          .ToListAsync();
            }

            items = totalItems
                          .Skip(pageIndex * pageSize)
                           .Take(pageSize).ToList();

            var itemsCount = totalItems.Count();
            */
            
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

        /*

        //This service looks for particular event details
        [HttpGet]
        [Route("item")]
        public async Task<IActionResult> Item(
            [FromQuery]int eventId)
        {
            var item = await _context.EventItems
                         .Where(i => i.Id == eventId)
                          .ToListAsync();

            var items = ChangePictureUrl(item);
            return Ok(items[0]);
        }
        */

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