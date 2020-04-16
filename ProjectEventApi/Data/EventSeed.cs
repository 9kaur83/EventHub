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
               /*  new EventItem { EventTypeId = 1, Description = "we sip, paint, and have some in the house fun!", Name = "Sip&Paint:PaintNite", Venue = "Online", Location = "Redmond", StartTime = new DateTime(2020, 04, 20, 13, 30, 0) , EndTime = new DateTime(2020, 04, 20, 14, 30, 0), Price = 25M, PictureUrl = "http://baseurltobereplaced/api/pic/1" },
                new EventItem { EventTypeId = 2, Description = "It is rich,creamy,cottage cheese dish prepared using butter", Name = "IndianCookingLesson:Paneer Butter Masala", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 18, 12, 30, 0) , EndTime = new DateTime(2020, 04, 18, 13, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/2" },
                new EventItem { EventTypeId = 3, Description = "Let's listen some music & have some in the house fun!", Name = "ShankarMahadevanLIVE Online", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 15, 12, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 45M, PictureUrl = "http://baseurltobereplaced/api/pic/3" },
                new EventItem { EventTypeId = 4, Description = "Let's Bake,we thought we'd bring the Bakehouse to you, virtually!", Name = "Bakehouse LIVE: Homemade Cinnamon Rolls", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 04, 15, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 14, 30, 0), Price = 55M, PictureUrl = "http://baseurltobereplaced/api/pic/4" },
                new EventItem { EventTypeId = 5, Description = "Breathe, Meditate & Be Happy! Learn the power of your own breath!", Name = "Beyond Breath Online - An Introduction to the Happiness Program", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 15, 06, 30, 0) , EndTime = new DateTime(2020, 04, 17, 13, 30, 0), Price = 75M, PictureUrl = "http://baseurltobereplaced/api/pic/5" },
                new EventItem { EventTypeId = 1, Description = "Let take the workout PowerHour fitness format for busy people.", Name = "Virtual Zumba Blast", Venue = "Online", Location = "Redmond", StartTime = new DateTime(2020, 04, 13, 10, 30, 0) , EndTime = new DateTime(2020, 04, 13, 11, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/6" },
                new EventItem { EventTypeId = 2, Description = "fun day for the kids, with lots of props and activities to do!", Name = "Kids Photography", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 04, 13, 10, 30, 0) , EndTime = new DateTime(2020, 04, 15, 11, 30, 0), Price = 25M, PictureUrl = "http://baseurltobereplaced/api/pic/7" },
                new EventItem { EventTypeId = 3, Description = "Learn how to get started with writing stories from your imagination!", Name = "Childrens Story Writing Workshops", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 5M, PictureUrl = "http://baseurltobereplaced/api/pic/8" },
                new EventItem { EventTypeId = 5, Description = "keep your kids creative and engaged.Minimal Supplies and Maximum Fun!", Name = "Online Kids Craft & Activities", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 13, 11, 30, 0) , EndTime = new DateTime(2020, 04, 13, 12, 30, 0), Price = 10M, PictureUrl = "http://baseurltobereplaced/api/pic/9" },
                new EventItem { EventTypeId = 1, Description = "Dance to all your favorite Bollywood and other regional hits all night long!", Name = "BollyWood Fusion Boat Party", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 05, 23, 03, 30, 0) , EndTime = new DateTime(2020, 05, 23, 05, 30, 0), Price = 100M, PictureUrl = "http://baseurltobereplaced/api/pic/10" },
                new EventItem { EventTypeId = 2, Description = "This 45-minute heart-pumping dance workout will keep you burning those calories.", Name = "Virtual Bollywood Cardio", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 13, 10, 30, 0) , EndTime = new DateTime(2020, 04, 13, 11, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/11" },
                new EventItem { EventTypeId = 3, Description = "Let's have family friendly daytime celebration!", Name = "Holi Hai : Color Festival", Venue = "Online", Location = "Redmond", StartTime = new DateTime(2020, 04, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/12" },
                new EventItem { EventTypeId = 4, Description = "Come join for some fun with Bhangra dance classes! !", Name = "Learn Bhangra: Bringing BHANGRA to everyone", Venue = "Online", Location = "Bothell", StartTime = new DateTime(2020, 04, 20, 06, 30, 0) , EndTime = new DateTime(2020, 04, 20, 06, 30, 0), Price = 20M, PictureUrl = "http://baseurltobereplaced/api/pic/13" },
                new EventItem { EventTypeId = 4, Description = "Come join us have some fun in Run!", Name = "5K Run", Venue = "Online", Location = "Seattle", StartTime = new DateTime(2020, 05, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 15M, PictureUrl = "http://baseurltobereplaced/api/pic/14" },
                new EventItem { EventTypeId = 4, Description = "Come join us !", Name = "Senior Get Together", Venue = "Online", Location = "Redmond", StartTime = new DateTime(2020, 04, 13, 13, 30, 0) , EndTime = new DateTime(2020, 04, 15, 13, 30, 0), Price = 5M, PictureUrl = "http://baseurltobereplaced/api/pic/15" },
            */
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
 