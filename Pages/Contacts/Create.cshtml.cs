using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using McpWebApp.Data;
using System.Threading.Tasks;

namespace McpWebApp.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public CreateModel(ContactCenterContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Contact Contact { get; set; } = new Contact();
        public void OnGet() { }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            _context.Contacts.Add(Contact);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
