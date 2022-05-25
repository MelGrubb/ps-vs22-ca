using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Greenfield.Web.Model;
using Greenfield.Web.Model.Context;
using Greenfield.Web.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Greenfield.Web.Pages.Properties
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly GreenfieldContext context;

        public IndexModel(GreenfieldContext context)
        {
            this.context = context;
        }

        public IList<Property> Properties { get;set; }

        public async Task OnGetAsync()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Properties = await context.Properties
                .Where(x => x.OwnerId == userId)
                .ToListAsync();
        }
    }
}
