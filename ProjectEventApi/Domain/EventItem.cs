using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEventApi.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Fees { get; set; }
        public string PictureUrl { get; set; }
        public int EventTypeId { get; set; }
        public int EventLocationZipcode { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual EventLocation EventLocation { get; set; }




    }
}
