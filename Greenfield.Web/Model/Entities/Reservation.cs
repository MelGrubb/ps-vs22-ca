using Greenfield.Web.Model.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Greenfield.Web.Model.Entities
{
    public class Reservation : Entity
    {
        [Key]
        public Guid Id { get; set; }

        public virtual Property Property { get; set; }

        [Required]
        [Display(Name = nameof(Property))]
        public Guid PropertyId { get; set; }

        public virtual ApplicationUser Client { get; set; }

        [Required]
        [Display(Name = nameof(Client))]
        public Guid ClientId { get; set; }

        /// <summary>The date of the reservation.</summary>
        /// <remarks>EF Core has no DateOnly support, only DateTime. The time portion will not be used.</remarks>
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public enum ReservationType
        {
            Daytime = 1,
            Overnight = 23
        }

        /// <summary>Entity type configuration for the <see cref="Reservation"/> class.</summary>
        public class Configuration : IEntityTypeConfiguration<Reservation>
        {
            public void Configure(EntityTypeBuilder<Reservation> builder)
            {
                builder.HasOne(x => x.Client).WithMany(x => x.Reservations).IsRequired().OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(x => x.Property).WithMany(x => x.Reservations).IsRequired().OnDelete(DeleteBehavior.NoAction);
                builder.HasData(GF1R1, GF1R2, GF2R1, GF2R2, GF3R1, GF3R2);
            }

            public static readonly Reservation GF1R1 = new Reservation
            {
                Id = Guid.Parse("47726565-6E66-6965-6C64-315265733031"),
                ClientId = ApplicationUser.Configuration.TestUser.Id,
                PropertyId = Property.Configuration.GreenfieldProperty1.Id,
                Date = new DateTime(2022, 01, 01),
                CreatedAt = new DateTime(2022, 03, 04),
                CreatedBy = "Seed Data",
                UpdatedAt = new DateTime(2022, 03, 04),
                UpdatedBy = "Seed Data",
            };

            public static readonly Reservation GF1R2 = new Reservation
            {
                Id = Guid.Parse("47726565-6E66-6965-6C64-315265733032"),
                ClientId = ApplicationUser.Configuration.TestUser.Id,
                PropertyId = Property.Configuration.GreenfieldProperty1.Id,
                Date = new DateTime(2022, 01, 02),
                CreatedAt = new DateTime(2022, 03, 04),
                CreatedBy = "Seed Data",
                UpdatedAt = new DateTime(2022, 03, 04),
                UpdatedBy = "Seed Data",
            };

            public static readonly Reservation GF2R1 = new Reservation
            {
                Id = Guid.Parse("47726565-6E66-6965-6C64-325265733031"),
                ClientId = ApplicationUser.Configuration.TestUser.Id,
                PropertyId = Property.Configuration.GreenfieldProperty2.Id,
                Date = new DateTime(2022, 02, 01),
                CreatedAt = new DateTime(2022, 03, 04),
                CreatedBy = "Seed Data",
                UpdatedAt = new DateTime(2022, 03, 04),
                UpdatedBy = "Seed Data",
            };

            public static readonly Reservation GF2R2 = new Reservation
            {
                Id = Guid.Parse("47726565-6E66-6965-6C64-325265733032"),
                ClientId = ApplicationUser.Configuration.TestUser.Id,
                PropertyId = Property.Configuration.GreenfieldProperty2.Id,
                Date = new DateTime(2022, 02, 02),
                CreatedAt = new DateTime(2022, 03, 04),
                CreatedBy = "Seed Data",
                UpdatedAt = new DateTime(2022, 03, 04),
                UpdatedBy = "Seed Data",
            };

            public static readonly Reservation GF3R1 = new Reservation
            {
                Id = Guid.Parse("47726565-6E66-6965-6C64-335265733031"),
                ClientId = ApplicationUser.Configuration.TestUser.Id,
                PropertyId = Property.Configuration.GreenfieldProperty3.Id,
                Date = new DateTime(2022, 03, 01),
                CreatedAt = new DateTime(2022, 03, 04),
                CreatedBy = "Seed Data",
                UpdatedAt = new DateTime(2022, 03, 04),
                UpdatedBy = "Seed Data",
            };

            public static readonly Reservation GF3R2 = new Reservation
            {
                Id = Guid.Parse("47726565-6E66-6965-6C64-335265733032"),
                ClientId = ApplicationUser.Configuration.TestUser.Id,
                PropertyId = Property.Configuration.GreenfieldProperty3.Id,
                Date = new DateTime(2022, 03, 02),
                CreatedAt = new DateTime(2022, 03, 04),
                CreatedBy = "Seed Data",
                UpdatedAt = new DateTime(2022, 03, 04),
                UpdatedBy = "Seed Data",
            };
        }
    }
}
