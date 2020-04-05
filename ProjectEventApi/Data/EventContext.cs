using Microsoft.EntityFrameworkCore;
using ProjectEventApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEventApi.Data
{
    public class EventContext:DbContext
    {
       public EventContext(DbContextOptions options)
            :base(options)
        {  }

        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventItem> EventItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventLocation>(e =>
            {
                e.ToTable("EventLocations");

                e.Property(b => b.Zipcode);
                e.HasKey(b => b.Zipcode);

                    
                e.Property(b => b.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            modelBuilder.Entity<EventType>(e =>
            {
                e.ToTable("EventType");
                e.Property(t => t.Id)
                    .IsRequired()
                    .UseHiLo("Event_type_hilo");

                e.Property(t => t.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            modelBuilder.Entity<EventItem>(e =>
            {
                e.ToTable("Event");
                e.Property(c => c.Id)
                    .IsRequired()
                    .UseHiLo("Event_hilo");

                e.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(c => c.Fees)
                    .IsRequired();

                e.HasOne(c => c.EventType)
                    .WithMany()
                    .HasForeignKey(c => c.EventTypeId);

                e.HasOne(c => c.EventLocation)
                    .WithMany()
                    .HasForeignKey(c => c.EventLocationZipcode);

             });
        }






    }
}
