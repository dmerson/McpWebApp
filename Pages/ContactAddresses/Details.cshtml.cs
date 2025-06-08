using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.ContactAddresses
{
    public class DetailsModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public DetailsModel(ContactCenterContext context)
        {
            _context = context;
        }
        public ContactAddress ContactAddress { get; set; } = new ContactAddress();
        [BindProperty(SupportsGet = true)]
        public int? ContactId { get; set; }
        public async Task<IActionResult> OnGetAsync(int id, int? contactId)
        {
            ContactAddress = await _context.ContactAddresses.FindAsync(id);
            if (ContactAddress == null)
                return NotFound();
            if (contactId.HasValue)
            {
                ContactAddress.ContactId = contactId.Value;
            }
            return Page();
        }
        public IActionResult OnPostBackToList()
        {
            // Redirect to Index with id query parameter
            return RedirectToPage("Index", new { id = ContactAddress.ContactId });
        }
    }
}
