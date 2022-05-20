using System;
using System.Linq;
using System.Threading.Tasks;
using Greenfield.Web.Model;
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
        private readonly GreenfieldContext _context;

        public EditModel(GreenfieldContext context)
        {
            _context = context;
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

            Property = await _context.Properties.FirstOrDefaultAsync(m => m.Id == id);

            if (Property == null)
            {
                return NotFound();
            }

            originalName = Property.Name;

            PropertyTypeList = new SelectList(_context.PropertyTypes, nameof(PropertyType.Id), nameof(PropertyType.Name));

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

            _context.Attach(Property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
