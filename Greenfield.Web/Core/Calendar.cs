using Greenfield.Web.Model;
using Greenfield.Web.Model.Context;
using Greenfield.Web.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Greenfield.Web
{
    public class Calendar
    {
        public DateTime[] findAvailability(GreenfieldContext context, Property property, int days)
        {
            int count=0;
            var reservations=property.Reservations.Where(x => (x.Date > DateTime.Today));
            var dates=new List<DateTime>();
            for (int i=0; i < days; i++)
            {
                if(reservations.Where(x => (x.Date == DateTime.Today.AddDays(i))).Count() == 0)
                {
                    dates.Add(DateTime.Today.AddDays(i));
                }
            }

            return dates.ToArray();
        }

        public Reservation makeReservation(GreenfieldContext context, Property property, ApplicationUser client, DateTime date)
        {
            if (property.Reservations.Where(x => (x.Date == date)).Count() != 0)
            {
                throw new InvalidOperationException("A reservation already exists for that day.");
            }
            else
            {
                return new Reservation { Client=client, Date=date };
            }
        }
    }
}
