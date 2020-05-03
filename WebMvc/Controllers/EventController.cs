using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int? page, int? locationFilterApplied, int? typesFilterApplied)
        {
            var itemsOnPage = 10;

            var event1 = await _service.GetEventItemsAsync(page?? 0, itemsOnPage, locationFilterApplied, typesFilterApplied);
            var vm = new EventIndexViewModel
            {
                EventItems = event1.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = event1.Count,
                    TotalPages = (int)Math.Ceiling((decimal)event1.Count / itemsOnPage)
                },
                Types = await _service.GetTypesAsync(),
                Locations = await _service.GetLocationsAsync(),
                LocationFilterApplied = locationFilterApplied ?? 0,
                TypesFilterApplied = typesFilterApplied ?? 0
            };

            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}


