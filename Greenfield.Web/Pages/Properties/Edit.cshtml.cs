using System;
using System.Linq;
using System.Threading.Tasks;
using Greenfield.Web.Model;
using Greenfield.Web.Model.Context;
using Greenfield.Web.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Greenfield.Web.Pages.Properties
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly GreenfieldContext context;

        public EditModel(GreenfieldContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Property Property { get; set; }

        private string originalName;

        public SelectList PropertyTypeList { get; set; }

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

            originalName = Property.Name;

            PropertyTypeList = new SelectList(context.PropertyTypes, nameof(PropertyType.Id), nameof(PropertyType.Name));

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

            if(Property.Name.ToUpper() == originalName.ToUpper())
            {

            }

            context.Attach(Property).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(Property.Id))
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

        private bool PropertyExists(Guid id)
        {
            return context.Properties.Any(e => e.Id == id);
        }
    }
}
