﻿using System;

namespace ProjectEventApi.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Venue { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int EventTypeId { get; set; }
        public int EventLocationId { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual EventLocation EventLocation { get; set; }
    }
}
