using InvoiceProcessingAPI.Data;
using InvoiceProcessingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
 
namespace InvoiceProcessingAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]


    public class InvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        //private static List<Invoice> invoices = new List<Invoice>
        //{
        //    new Invoice
        //    {
        //        Id = 1,
        //        CustomerName = "ABC Company",
        //        Amount = 5000,
        //        Status = "Processed"
        //    },
        //    new Invoice
        //    {
        //        Id = 2,
        //        CustomerName = "XYZ Ltd",
        //        Amount = 7000,
        //        Status = "Pending"
        //    }
        //};

        [HttpPost]
        public IActionResult AddInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            return Ok(invoice);
        }
        [HttpGet]
        public IActionResult GetInvoices()
        {
            var invoices = _context.Invoices.ToList();

            return Ok(invoices);
        }
        [HttpGet("{id}")]
        public IActionResult GetInvoiceById(int id)
        {
            var invoice = _context.Invoices.Find(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInvoice(int id, Invoice updatedInvoice)
        {
            var invoice = _context.Invoices.Find(id);

            if (invoice == null)
            {
                return NotFound();
            }

            invoice.CustomerName = updatedInvoice.CustomerName;
            invoice.Amount = updatedInvoice.Amount;
            invoice.Status = updatedInvoice.Status;

            _context.SaveChanges();

            return Ok(invoice);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            var invoice = _context.Invoices.Find(id);

            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            _context.SaveChanges();

            return Ok("Invoice deleted successfully");
        }
        [HttpGet("status/{status}")]
        public IActionResult GetInvoicesByStatus(string status)
        {
            var invoices = _context.Invoices
                                   .Where(i => i.Status == status)
                                   .ToList();

            return Ok(invoices);
        }
    }

}
