using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.ContactPhones
{
    public class CreateModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public CreateModel(ContactCenterContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ContactPhone ContactPhone { get; set; } = new ContactPhone();
        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }
        public void OnGet()
        {
            if (Id.HasValue)
            {
                ContactPhone.ContactId = Id.Value;
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            _context.ContactPhones.Add(ContactPhone);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
