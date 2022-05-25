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

namespace Greenfield.Web.Pages.Properties
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Greenfield.Web.Model.Context.GreenfieldContext context;

        public CreateModel(Greenfield.Web.Model.Context.GreenfieldContext context)
        {
            this.context = context;
        }

        public IActionResult OnGet()
        {
            PropertyTypeList = new SelectList(context.PropertyTypes, nameof(PropertyType.Id), nameof(PropertyType.Name));

            return Page();
        }

        [BindProperty]
        public Property Property { get; set; }

        public SelectList PropertyTypeList { get; set; }
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Guid clientId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Property.OwnerId = clientId;

            context.Properties.Add(Property);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
