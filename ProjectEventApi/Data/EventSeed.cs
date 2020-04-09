using Microsoft.EntityFrameworkCore;
using ProjectEventApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEventApi.Data
{
    public  static class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();
            if(!context.EventLocations.Any())
            {
                context.EventLocations.AddRange(GetPreConfiguredEventLocations());
                context.SaveChanges();
            }
            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetPreConfiguredEventTypes());
                context.SaveChanges();
            }
            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetPreConfiguredEventItems());
                
                context.SaveChanges();
            }
        }

        private static IEnumerable <EventItem>GetPreConfiguredEventItems()
        {
            return new List<EventItem>
            {
                new EventItem { EventTypeId=2,EventLocationId=3, Description = "Indian festival of color", Venue = "church",Start_dateTime= DateTime.Parse("04/08/2020 09:00:00"),End_dateTime = DateTime.Parse("04/18/2020 11:00:00"), Name = "Holi", TicketPrice  = 10.09M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/1" },
                new EventItem { EventTypeId=1,EventLocationId=2, Description = "Bollywood dance is the dance-form used in the Indian films.", Venue = "church",Start_dateTime= DateTime.Parse( "04/07/2020 09:00:00"),End_dateTime = DateTime.Parse("04/17/2020 11:00:00"), Name = "Bollywood Dance", TicketPrice = 8.90M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/2" },
                new EventItem { EventTypeId=2,EventLocationId=3, Description = "Pottery is made by forming a ceramic (often clay) body into objects of a desired ", Venue = "church",Start_dateTime= DateTime.Parse("04/06/2020 09:00:00"),End_dateTime = DateTime.Parse("04/16/2020 11:00:00"), Name = "Pottery Making", TicketPrice = 12.09M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/3" },
                new EventItem { EventTypeId=2,EventLocationId=2, Description = "A mural is any piece of artwork painted or applied directly on a wall", Venue = "church",Start_dateTime= DateTime.Parse("04/05/2020 09:00:00"),End_dateTime = DateTime.Parse("04/15/2020 11:00:00"), Name = "Mural Painting", TicketPrice = 12.02M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/4" },
            };
        }
        private static IEnumerable<EventType> GetPreConfiguredEventTypes()

        {
            return new List<EventType>
            {
                new EventType { Type = "Holi" },
                new EventType{ Type = "Bollywood Dance"},
                new EventType{ Type ="Pottery Making"},
                new EventType{ Type = "Mural Painting"}
            };
        }

        private static IEnumerable<EventLocation>GetPreConfiguredEventLocations()
        {
            return new List<EventLocation>
            {
              new EventLocation{ Name = "Evertt",Zipcode = 98203},
              new EventLocation{ Name = "Bothell",Zipcode = 98012},
              new EventLocation{ Name = "Redmond",Zipcode = 98008},
              new EventLocation{ Name = "Lynnwood",Zipcode = 98036}

            };
          
        }
    }
}
 