using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Greenfield.Web.Model;
using Greenfield.Web.Model.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Greenfield.Web.Pages.Reservations
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Greenfield.Web.Model.Context.GreenfieldContext context;

        public DetailsModel(Greenfield.Web.Model.Context.GreenfieldContext context)
        {
            this.context = context;
        }

        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation = await context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Property).FirstOrDefaultAsync(m => m.Id == id);

            if (Reservation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
