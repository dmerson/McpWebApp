using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public EditModel(ContactCenterContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Contact Contact { get; set; } = new Contact();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contact = await _context.Contacts.FindAsync(id);
            if (Contact == null)
                return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            _context.Attach(Contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
