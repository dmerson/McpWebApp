using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using McpWebApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McpWebApp.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public IndexModel(ContactCenterContext context)
        {
            _context = context;
        }
        public IList<Contact> Contacts { get; set; } = new List<Contact>();
        public async Task OnGetAsync()
        {
            Contacts = await _context.Contacts.ToListAsync();
        }
    }
}
