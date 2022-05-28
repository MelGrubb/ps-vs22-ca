using Greenfield.Web.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Greenfield.Web.Pages.Properties
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
        public Property Property { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await context.Properties.FirstOrDefaultAsync(m => m.Id == id);

            if (Property == null)
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

            Property = await context.Properties.FindAsync(id);

            if (Property != null)
            {
                context.Properties.Remove(Property);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
