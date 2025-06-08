using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using McpWebApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McpWebApp.Pages.ContactAddresses
{
    public class IndexModel : PageModel
    {
        private readonly ContactCenterContext _context;
        public IndexModel(ContactCenterContext context)
        {
            _context = context;
        }
        public IList<ContactAddress> ContactAddresses { get; set; } = new List<ContactAddress>();
        public async Task OnGetAsync()
        {
            ContactAddresses = await _context.ContactAddresses.ToListAsync();
        }
    }
}
