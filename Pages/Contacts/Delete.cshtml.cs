using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public DeleteModel(ContactCenterContext context)
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
            var contact = await _context.Contacts.FindAsync(Contact.Id);
            if (contact == null)
                return NotFound();
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
