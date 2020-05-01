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

            if (!context.EventLocations.Any())
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

            //context.Database.ExecuteSqlCommand("ALTER SEQUENCE Event_location_hilo RESTART WITH 1");
            //context.Database.ExecuteSqlCommand("ALTER SEQUENCE Event_type_hilo RESTART WITH 1");
            //context.Database.ExecuteSqlCommand("ALTER SEQUENCE Event_hilo RESTART WITH 1");

            //context.EventLocations.RemoveRange(context.EventLocations);
            //context.EventTypes.RemoveRange(context.EventTypes);
            //context.EventItems.RemoveRange(context.EventItems);
            //context.SaveChanges();

            /*context.EventLocations.AddRange(GetPreConfiguredEventLocations());
            context.EventTypes.AddRange(GetPreConfiguredEventTypes());
            context.EventItems.AddRange(GetPreConfiguredEventItems());
            context.SaveChanges();*/
        }

        private static IEnumerable <EventItem>GetPreConfiguredEventItems()
        {
            return new List<EventItem>
            {
                new EventItem { EventTypeId = 1,EventLocationId=3, Description = "we sip, paint, and have some in the house fun!", Name = "Sip&Paint:PaintNite", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 25.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/1" },
                new EventItem { EventTypeId = 4,EventLocationId=2, Description = "It is rich,creamy,cottage cheese dish prepared using butter", Name = "IndianCookingLesson:Paneer Butter Masala", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 15.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/2" },
                new EventItem { EventTypeId = 3,EventLocationId=2, Description = "Let's listen some music & have some in the house fun!", Name = "ShankarMahadevanLIVE Online", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 45M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/3" },
                new EventItem { EventTypeId = 4,EventLocationId=1, Description = "Let's Bake,we thought we'd bring the Bakehouse to you, virtually!", Name = "Bakehouse LIVE: Homemade Cinnamon Rolls", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 55.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/4" },
                new EventItem { EventTypeId = 1,EventLocationId=2, Description = "Breathe, Meditate & Be Happy! Learn the power of your own breath!", Name = "Beyond Breath Online - An Introduction to the Happiness Program", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 75.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/5" },
                new EventItem { EventTypeId = 1,EventLocationId=3, Description = "Let take the workout PowerHour fitness format for busy people.", Name = "Virtual Zumba Blast", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 15.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/6" },
                new EventItem { EventTypeId = 2,EventLocationId=1, Description = "fun day for the kids, with lots of props and activities to do!", Name = "Kids Photography", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 25.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/7" },
                new EventItem { EventTypeId = 2,EventLocationId=2, Description = "Learn how to get started with writing stories from your imagination!", Name = "Childrens Story Writing Workshops", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 5.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/8" },
                new EventItem { EventTypeId = 2,EventLocationId=2, Description = "keep your kids creative and engaged.Minimal Supplies and Maximum Fun!", Name = "Online Kids Craft & Activities", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 10.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/9" },
                new EventItem { EventTypeId = 3,EventLocationId=1, Description = "Dance to all your favorite Bollywood and other regional hits all night long!", Name = "BollyWood Fusion Boat Party", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 100.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/10" },
                new EventItem { EventTypeId = 3,EventLocationId=2, Description = "This 45-minute heart-pumping dance workout will keep you burning those calories.", Name = "Virtual Bollywood Cardio", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 15.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/11" },
                new EventItem { EventTypeId = 5,EventLocationId=3, Description = "Let's have family friendly daytime celebration!", Name = "Holi Hai : Color Festival", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 15.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/12" },
                new EventItem { EventTypeId = 3,EventLocationId=2, Description = "Come join for some fun with Bhangra dance classes! !", Name = "Learn Bhangra: Bringing BHANGRA to everyone", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 20.00M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/13" },
                new EventItem { EventTypeId = 1,EventLocationId=1, Description = "Come join us have some fun in Run!", Name = "5K Run", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 15M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/14" },
                new EventItem { EventTypeId = 1,EventLocationId=3, Description = "Come join us !", Name = "Senior Get Together", Venue = "Online",StartTime= DateTime.Parse("04/05/2020 09:00:00"),EndTime = DateTime.Parse("04/05/2020 11:00:00"), Price = 5M, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/15" }
               
            };
        }
        private static IEnumerable<EventType> GetPreConfiguredEventTypes()
        {
            return new List<EventType>
            {
                new EventType { Type = "Recreational Activity" },
                new EventType { Type = "Kids Activity" },
                new EventType { Type = "Music & Dance" },
                new EventType { Type = "Cooking" },
                new EventType { Type = "Festivals"}        
            };
        }

        private static IEnumerable<EventLocation>GetPreConfiguredEventLocations()
        {
            return new List<EventLocation>
            {
              new EventLocation{ Name = "Seattle",Zipcode = 98101},
              new EventLocation{ Name = "Bothell",Zipcode = 98012},
              new EventLocation{ Name = "Redmond",Zipcode = 98008},
              new EventLocation{ Name = "Lynnwood",Zipcode = 98036}

            };
          
        }
    }
}
 