using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Greenfield.Web.Model.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Greenfield.Web.Model.Entities
{
    public class PropertyType : Entity
    {
        public PropertyType()
        {
            Properties=new HashSet<Property>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required] 
        [StringLength(50)] 
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        public virtual ICollection<Property> Properties { get; }

        /// <summary>Entity type configuration for the <see cref="PropertyType"/> class.</summary>
        public class Configuration : IEntityTypeConfiguration<PropertyType>
        {
            public void Configure(EntityTypeBuilder<PropertyType> builder)
            {
                builder.HasData(Rough, Cleared, Manicured);
            }

            public static DataBuilder<PropertyType> AddToBuilder(ModelBuilder builder)
            {
                return builder.Entity<PropertyType>().HasData(Rough);
            }

            public static readonly PropertyType Rough=new PropertyType
            {
                Id=Guid.Parse("50726F70-6572-7479-5479-7065526F7567"),
                Name="Rough",
                Description="Raw, undeveloped prairie land. May contain gopher holes. Watch your step, and bring bug repellant.",
                CreatedAt=new DateTime(2022, 03, 04),
                CreatedBy="Seed Data",
                UpdatedAt=new DateTime(2022, 03, 04),
                UpdatedBy="Seed Data",
            };

            public static readonly PropertyType Cleared=new PropertyType
            {
                Id=Guid.Parse("50726F70-6572-7479-5479-7065436C6561"),
                Name="Cleared",
                Description="Cleared land, fairly flat, mowed occasionally.",
                CreatedAt=new DateTime(2022, 03, 04),
                CreatedBy="Seed Data",
                UpdatedAt=new DateTime(2022, 03, 04),
                UpdatedBy="Seed Data",
            };

            public static readonly PropertyType Manicured=new PropertyType
            {
                Id=Guid.Parse("50726F70-6572-7479-5479-70654D616E69"),
                Name="Manicured",
                Description="A meticulously maintained meadow, matchless for meditative mollification and mitigation of metropolitan misery. May contain mosquitoes.",
                CreatedAt=new DateTime(2022, 03, 04),
                CreatedBy="Seed Data",
                UpdatedAt=new DateTime(2022, 03, 04),
                UpdatedBy="Seed Data",
            };
        }
    }
}