using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using McpWebApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McpWebApp.Pages.ContactPhones
{
    public class IndexModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public IndexModel(ContactCenterContext context)
        {
            _context = context;
        }
        public IList<ContactPhone> ContactPhones { get; set; } = new List<ContactPhone>();
        public async Task OnGetAsync()
        {
            ContactPhones = await _context.ContactPhones.ToListAsync();
        }
    }
}
