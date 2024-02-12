using Microsoft.EntityFrameworkCore;

namespace Easyway.Models
{
    public class ContactDBContext : DbContext
    {
        public ContactDBContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Contactinfo> Contactinfos { get; set; } = null!;
    }
}
