

using InvoiceProcessingAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace InvoiceProcessingAPI.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
    }
}
