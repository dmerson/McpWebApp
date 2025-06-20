using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.ContactPhones
{
    public class EditModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public EditModel(ContactCenterContext context)
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
            if (!ModelState.IsValid)
                return Page();
            _context.Attach(ContactPhone).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            // Redirect to Index with id query parameter
            return RedirectToPage("Index", new { id = ContactPhone.ContactId });
        }
    }
}
