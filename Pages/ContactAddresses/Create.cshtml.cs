using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.ContactAddresses
{
    public class CreateModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public CreateModel(ContactCenterContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ContactAddress ContactAddress { get; set; } = new ContactAddress();
        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }
        public void OnGet()
        {
            if (Id.HasValue)
            {
                ContactAddress.ContactId = Id.Value;
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            _context.ContactAddresses.Add(ContactAddress);
            await _context.SaveChangesAsync();
            // Redirect to Index with id query parameter
            return RedirectToPage("Index", new { id = ContactAddress.ContactId });
        }
    }
}
