using Greenfield.Web.Model.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Greenfield.Web.Model.Entities
{
    /// <summary>Defines an available day for a Property.</summary>
    public class Availability : Entity
    {
        /// <summary>Unique identifier for this Availability.</summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>The day of the week for this Availability.</summary>
        public DayOfWeek DayOfWeek { get; set; }

        /// <summary>The check-in time for this Availability.</summary>
        /// <remarks>We won't be enforcing these, to a string is fine.</remarks>
        public string CheckIn { get; set; }

        /// <summary>The check-out time for this Availability.</summary>
        /// <remarks>We won't be enforcing these, to a string is fine.</remarks>
        public string CheckOut { get; set; }

        /// <summary>The property owner's notes about the Availability.</summary>
        [StringLength(250)]
        public string Notes { get; set; }

        public virtual Property Property { get; set; }

        [Required]
        [Display(Name = nameof(Property))]
        public Guid PropertyId { get; set; }

        public class Configuration : IEntityTypeConfiguration<Availability>
        {
            public void Configure(EntityTypeBuilder<Availability> builder)
            {
                builder.HasOne(x => x.Property).WithMany(x => x.Availabilities).IsRequired().OnDelete(DeleteBehavior.NoAction);
                builder.HasData(GF1A1, GF1A2, GF1A3);
            }

            public static readonly Availability GF1A1 = new Availability
            {
                Id = Guid.Parse("47726565-6E66-6965-6C64-303141763031"),
                CheckIn = "3PM",
                CheckOut = "11AM",
                DayOfWeek = DayOfWeek.Friday,
                PropertyId = Property.Configuration.GreenfieldProperty1.Id,
                Notes = "Friday availability at GreenfieldProperty1",
                CreatedAt = new DateTime(2022, 03, 04),
                CreatedBy = "Seed Data",
                UpdatedAt = new DateTime(2022, 03, 04),
                UpdatedBy = "Seed Data",
            };

            public static readonly Availability GF1A2 = new Availability
            {
                Id = Guid.Parse("47726565-6E66-6965-6C64-303141763032"),
                CheckIn = "3PM",
                CheckOut = "11AM",
                DayOfWeek = DayOfWeek.Saturday,
                PropertyId = Property.Configuration.GreenfieldProperty1.Id,
                Notes = "Saturday availability at GreenfieldProperty1",
                CreatedAt = new DateTime(2022, 03, 04),
                CreatedBy = "Seed Data",
                UpdatedAt = new DateTime(2022, 03, 04),
                UpdatedBy = "Seed Data",
            };

            public static readonly Availability GF1A3 = new Availability
            {
                Id = Guid.Parse("47726565-6E66-6965-6C64-303141763033"),
                CheckIn = "3PM",
                CheckOut = "11AM",
                DayOfWeek = DayOfWeek.Sunday,
                PropertyId = Property.Configuration.GreenfieldProperty1.Id,
                Notes = "Sunday availability at GreenfieldProperty1",
                CreatedAt = new DateTime(2022, 03, 04),
                CreatedBy = "Seed Data",
                UpdatedAt = new DateTime(2022, 03, 04),
                UpdatedBy = "Seed Data",
            };
        }
    }
}