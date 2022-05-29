using Greenfield.Web.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Greenfield.Web.Core
{
    public class Calendar
    {
        public DateTime[] FindAvailability(Property property, int days)
        {
            IEnumerable<Reservation> reservations = property.Reservations.Where(x => x.Date > DateTime.Today);
            List<DateTime> dates = new();
            for (int i = 0; i < days; i++)
            {
                if (!reservations.Any(x => x.Date == DateTime.Today.AddDays(i)))
                {
                    dates.Add(DateTime.Today.AddDays(i));
                }
            }
            return dates.ToArray();
        }

        public Reservation MakeReservation(Property property, ApplicationUser client, DateTime date)
        {
            return property.Reservations.Any(x => x.Date == date)
                ? throw new InvalidOperationException("A reservation already exists for that day.")
                : new Reservation { Client = client, Date = date };
        }
    }
}
