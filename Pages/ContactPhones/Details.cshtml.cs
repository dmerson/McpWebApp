using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.ContactPhones
{
    public class DetailsModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public DetailsModel(ContactCenterContext context)
        {
            _context = context;
        }
        public ContactPhone ContactPhone { get; set; } = new ContactPhone();
        [BindProperty(SupportsGet = true)]
        public int? ContactId { get; set; }
        public async Task<IActionResult> OnGetAsync(int id, int? contactId)
        {
            ContactPhone = await _context.ContactPhones.FindAsync(id);
            if (ContactPhone == null)
                return NotFound();
            if (contactId.HasValue)
            {
                ContactPhone.ContactId = contactId.Value;
            }
            return Page();
        }
        public IActionResult OnPostBackToList()
        {
            // Redirect to Index with id query parameter
            return RedirectToPage("Index", new { id = ContactPhone.ContactId });
        }
    }
}
