using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Greenfield.Web.Model.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Greenfield.Web.Model.Entities;

public class Property : Entity
{
    public Property()
    {
        Availabilities = new HashSet<Availability>();
        Reservations = new HashSet<Reservation>();
    }

    [Key]
    public Guid Id { get; set; }

    [Required] 
    [StringLength(50)] 
    public string Name { get; set; }

    [Required]
    [StringLength(250)] 
    public string Description { get; set; }

    public virtual ApplicationUser Owner { get; set; }

    [Required] 
    public Guid OwnerId { get; set; }

    [Display(Name = "Type")] 
    public virtual PropertyType PropertyType { get; set; }

    [Required] 
    public Guid PropertyTypeId { get; set; }

    [Display(Name = "Availability")] 
    public virtual ICollection<Availability> Availabilities { get; }
    public virtual ICollection<Reservation> Reservations { get; }

    /// <summary>Entity type configuration for the <see cref="Property"/> class.</summary>
    public class Configuration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasOne(x => x.Owner).WithMany(x => x.Properties).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.PropertyType).WithMany(x => x.Properties).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasData(GreenfieldProperty1, GreenfieldProperty2, GreenfieldProperty3, TestProperty1);
        }

        public static readonly Property GreenfieldProperty1 = new Property
        {
            Id = Guid.Parse("47726565-6E66-6965-6C64-50726F703031"),
            Name = "Greenfield Property #1",
            Description = "A plain, undeveloped field to the North of Greenfield's own headquarters.",
            OwnerId = ApplicationUser.Configuration.SystemAdmin.Id,
            PropertyTypeId = PropertyType.Configuration.Rough.Id,
            CreatedAt = new DateTime(2022, 03, 04),
            CreatedBy = "Seed Data",
            UpdatedAt = new DateTime(2022, 03, 04),
            UpdatedBy = "Seed Data",
        };

        public static readonly Property GreenfieldProperty2 = new Property
        {
            Id = Guid.Parse("47726565-6E66-6965-6C64-50726F703032"),
            Name = "Greenfield Property #2",
            Description = "A plain, but somewhat nicer field to the East of Greenfield's own headquarters.",
            OwnerId = ApplicationUser.Configuration.SystemAdmin.Id,
            PropertyTypeId = PropertyType.Configuration.Cleared.Id,
            CreatedAt = new DateTime(2022, 03, 04),
            CreatedBy = "Seed Data",
            UpdatedAt = new DateTime(2022, 03, 04),
            UpdatedBy = "Seed Data",
        };

        public static readonly Property GreenfieldProperty3 = new Property
        {
            Id = Guid.Parse("47726565-6E66-6965-6C64-50726F703033"),
            Name = "Greenfield Property #3",
            Description = "A flower-filled meadow on the outskirts of town to the West of Greenfield's headquarters. Far enough to escape the city, but close enough to order pizza.",
            OwnerId = ApplicationUser.Configuration.SystemAdmin.Id,
            PropertyTypeId = PropertyType.Configuration.Manicured.Id,
            CreatedAt = new DateTime(2022, 03, 04),
            CreatedBy = "Seed Data",
            UpdatedAt = new DateTime(2022, 03, 04),
            UpdatedBy = "Seed Data",
        };

        public static readonly Property TestProperty1 = new Property
        {
            Id = Guid.Parse("54657374-5573-6572-5072-6F7065723031"),
            Name = "Test User Property #1",
            Description = "Test User's back yard.",
            OwnerId = ApplicationUser.Configuration.TestUser.Id,
            PropertyTypeId = PropertyType.Configuration.Cleared.Id,
            CreatedAt = new DateTime(2022, 03, 04),
            CreatedBy = "Seed Data",
            UpdatedAt = new DateTime(2022, 03, 04),
            UpdatedBy = "Seed Data",
        };
    }
}