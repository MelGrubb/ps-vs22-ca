using Greenfield.Web.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Greenfield.Web.Pages.Reservations
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Greenfield.Web.Model.Context.GreenfieldContext context;

        public IndexModel(Greenfield.Web.Model.Context.GreenfieldContext context)
        {
            this.context = context;
        }

        public IList<Reservation> Reservation { get; set; }

        public async Task OnGetAsync()
        {
            Guid clientId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Reservation = await context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Property)
                .Where(x => x.ClientId == clientId)
                .ToListAsync();
        }
    }
}
