using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.ContactPhones
{
    public class DeleteModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public DeleteModel(ContactCenterContext context)
        {
            _context = context;
        }
        [BindProperty]
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
        public async Task<IActionResult> OnPostAsync()
        {
            var phone = await _context.ContactPhones.FindAsync(ContactPhone.Id);
            if (phone == null)
                return NotFound();
            int contactId = phone.ContactId;
            _context.ContactPhones.Remove(phone);
            await _context.SaveChangesAsync();
            // Redirect to Index with id query parameter
            return RedirectToPage("Index", new { id = contactId });
        }
    }
}
