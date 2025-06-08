using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public DetailsModel(ContactCenterContext context)
        {
            _context = context;
        }
        public Contact Contact { get; set; } = new Contact();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contact = await _context.Contacts.FindAsync(id);
            if (Contact == null)
                return NotFound();
            return Page();
        }
    }
}
