using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Greenfield.Web.Model.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Properties = new HashSet<Property>();
            Reservations = new HashSet<Reservation>();
        }

        /// <summary>Properties owned by this user.</summary>
        public virtual ICollection<Property> Properties { get; }

        /// <summary>Reservations at other owners' properties.</summary>
        public virtual ICollection<Reservation> Reservations { get; }

        /// <summary>Entity type configuration for the <see cref="Reservation"/> class.</summary>
        public class Configuration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                builder.HasData(SystemAdmin, TestUser);
            }

            public static readonly ApplicationUser SystemAdmin = new ApplicationUser
            {
                Id = Guid.Parse("47726565-6E66-6965-6C64-2041646D696E"),
                Email = "greenfield.admin@globomantics.com",
                NormalizedEmail = "GREENFIELD.ADMIN@GLOBOMANTICS.COM",
                UserName= "greenfield.admin@globomantics.com",
                NormalizedUserName= "GREENFIELD.ADMIN@GLOBOMANTICS.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAELLgUo3k2B/a/LRJIU5ucgdyS7oozdKeHyNikehK1tOKVpiZUgDdLlFeByjqhWXqdQ==",
                SecurityStamp = "BJTXU4I4ZJQKOES6TL2J5BLDWQ7ORJU4",
                ConcurrencyStamp = "8c466f08-5952-4030-8314-095370e8fa5f"
            };

            public static readonly ApplicationUser TestUser = new ApplicationUser
            {
                Id = Guid.Parse("2B320CE5-2F11-41BF-7EE8-08DA38685344"),
                Email = "greenfield.test@globomantics.com",
                NormalizedEmail = "GREENFIELD.TEST@GLOBOMANTICS.COM",
                UserName = "greenfield.test@globomantics.com",
                NormalizedUserName = "GREENFIELD.TEST@GLOBOMANTICS.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEPWmcKFWAlMNbjzMMiGqTn/jl7cOGBvgL+qMH9K+WHHxXZJnpP2xXH2nR1WSk6iGig==",
                SecurityStamp = "R5USH7ZAJLIAN6I4BMBUMMBLGLENARSZ",
                ConcurrencyStamp = "eabedbb8-ff91-42db-8aff-2bb92e479b59"
            };
        }
    }
}
