using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBills.Models.Entities;

namespace TestBills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsToPaysController : ControllerBase
    {
        private readonly BillsToPayContext _context;

        public BillsToPaysController(BillsToPayContext context)
        {
            _context = context;
        }

        // GET: api/BillsToPays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillsToPay>>> GetBillsToPay()
        {
            return await _context.BillsToPay.ToListAsync();
        }

        // GET: api/BillsToPays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillsToPay>> GetBillsToPay(int id)
        {
            var billsToPay = await _context.BillsToPay.FindAsync(id);

            if (billsToPay == null)
            {
                return NotFound();
            }

            return billsToPay;
        }

        // PUT: api/BillsToPays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillsToPay(int id, BillsToPay billsToPay)
        {
            if (id != billsToPay.Id)
            {
                return BadRequest();
            }

            _context.Entry(billsToPay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillsToPayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BillsToPays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillsToPay>> PostBillsToPay(BillsToPay billsToPay)
        {
        //    if (billsToPay.getDataVencimento() < billsToPay.getDataPagamento() { ..
        //    calculaValorComMulta(billsToPay);
        //}
        _context.BillsToPay.Add(billsToPay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillsToPay", new { id = billsToPay.Id }, billsToPay);
        }

        // DELETE: api/BillsToPays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillsToPay>> DeleteBillsToPay(int id)
        {
            var billsToPay = await _context.BillsToPay.FindAsync(id);
            if (billsToPay == null)
            {
                return NotFound();
            }

            _context.BillsToPay.Remove(billsToPay);
            await _context.SaveChangesAsync();

            return billsToPay;
        }

        private bool BillsToPayExists(int id)
        {
            return _context.BillsToPay.Any(e => e.Id == id);
        }
    }
}
