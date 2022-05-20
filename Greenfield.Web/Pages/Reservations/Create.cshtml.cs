using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Greenfield.Web.Model;
using Greenfield.Web.Model.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Greenfield.Web.Pages.Reservations
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Greenfield.Web.Model.GreenfieldContext _context;

        public CreateModel(Greenfield.Web.Model.GreenfieldContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["PropertyId"] = new SelectList(_context.Properties, nameof(Property.Id), nameof(Property.Name));
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser currentUser = _context.Users.Single(x => x.UserName == User.Identity.Name);
            Reservation.ClientId = currentUser.Id;
            Reservation.CreatedBy = Reservation.UpdatedBy = currentUser.UserName;
            Reservation.CreatedAt = Reservation.UpdatedAt = DateTime.Now;

            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
