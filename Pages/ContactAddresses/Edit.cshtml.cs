using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.ContactAddresses
{
    public class EditModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public EditModel(ContactCenterContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ContactAddress ContactAddress { get; set; } = new ContactAddress();
        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            _context.Attach(ContactAddress).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            // Redirect to Index with id query parameter
            return RedirectToPage("Index", new { id = ContactAddress.ContactId });
        }
    }
}
