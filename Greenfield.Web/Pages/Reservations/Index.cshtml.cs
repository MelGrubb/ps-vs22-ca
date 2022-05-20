using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class IndexModel : PageModel
    {
        private readonly Greenfield.Web.Model.GreenfieldContext _context;

        public IndexModel(Greenfield.Web.Model.GreenfieldContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; }

        public async Task OnGetAsync()
        {
            Guid clientId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Reservation = await _context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Property)
                .Where(x => x.ClientId == clientId)
                .ToListAsync();
        }
    }
}
