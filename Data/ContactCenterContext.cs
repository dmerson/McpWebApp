using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McpWebApp.Data
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public ICollection<ContactPhone> Phones { get; set; } = new List<ContactPhone>();
        public ICollection<ContactAddress> Addresses { get; set; } = new List<ContactAddress>();
    }

    public class ContactPhone
    {
        public int Id { get; set; }
        [Required]
        public string PhoneType { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        public int ContactId { get; set; }
        public Contact? Contact { get; set; }
    }

    public class ContactAddress
    {
        public int Id { get; set; }
        [Required]
        public string AddressType { get; set; } = string.Empty;
        [Required]
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        public string Zip { get; set; } = string.Empty;
        public int ContactId { get; set; }
        public Contact? Contact { get; set; }
    }

    public class ContactCenterContext : DbContext
    {
        public ContactCenterContext(DbContextOptions<ContactCenterContext> options) : base(options) { }
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<ContactPhone> ContactPhones => Set<ContactPhone>();
        public DbSet<ContactAddress> ContactAddresses => Set<ContactAddress>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContactPhone>()
                .HasOne(p => p.Contact)
                .WithMany(c => c.Phones)
                .HasForeignKey(p => p.ContactId);
            modelBuilder.Entity<ContactAddress>()
                .HasOne(a => a.Contact)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.ContactId);
        }
    }
}
