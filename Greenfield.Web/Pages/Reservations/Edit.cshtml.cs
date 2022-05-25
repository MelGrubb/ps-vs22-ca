using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Greenfield.Web.Model;
using Greenfield.Web.Model.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Greenfield.Web.Pages.Reservations
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Greenfield.Web.Model.Context.GreenfieldContext context;

        public EditModel(Greenfield.Web.Model.Context.GreenfieldContext context)
        {
            this.context = context;
        }

        [BindProperty]
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
           ViewData["ClientId"] = new SelectList(context.Users, "Id", "UserName");
           ViewData["PropertyId"] = new SelectList(context.Properties, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Attach(Reservation).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(Reservation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReservationExists(Guid id)
        {
            return context.Reservations.Any(e => e.Id == id);
        }
    }
}
