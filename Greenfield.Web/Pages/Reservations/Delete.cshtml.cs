using Greenfield.Web.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Greenfield.Web.Pages.Reservations
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly Greenfield.Web.Model.Context.GreenfieldContext context;

        public DeleteModel(Greenfield.Web.Model.Context.GreenfieldContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation = await context.Reservations.FindAsync(id);

            if (Reservation != null)
            {
                context.Reservations.Remove(Reservation);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
