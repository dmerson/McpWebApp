using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.ContactAddresses
{
    public class DeleteModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public DeleteModel(ContactCenterContext context)
        {
            _context = context;
        }
        [BindProperty]
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
        public async Task<IActionResult> OnPostAsync()
        {
            var address = await _context.ContactAddresses.FindAsync(ContactAddress.Id);
            if (address == null)
                return NotFound();
            int contactId = address.ContactId;
            _context.ContactAddresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index", new { id = contactId });
        }
    }
}
