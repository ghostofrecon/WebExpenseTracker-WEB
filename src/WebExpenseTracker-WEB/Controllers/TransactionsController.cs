using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using WebExpenseTracker_WEB.EF;

namespace WebExpenseTracker_WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/Transactions")]
    public class TransactionsController : Controller
    {
        private WebExpenseTrackerContext _context;

        public TransactionsController(WebExpenseTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public IEnumerable<Transactions> GetTransactions()
        {
            return _context.Transactions;
        }

        // GET: api/Transactions/5
        [HttpGet("{id}", Name = "GetTransactions")]
        public IActionResult GetTransactions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Transactions transactions = _context.Transactions.Single(m => m.TransactionID == id);

            if (transactions == null)
            {
                return HttpNotFound();
            }

            return Ok(transactions);
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public IActionResult PutTransactions(int id, [FromBody] Transactions transactions)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != transactions.TransactionID)
            {
                return HttpBadRequest();
            }

            _context.Entry(transactions).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionsExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Transactions
        [HttpPost]
        public IActionResult PostTransactions([FromBody] Transactions transactions)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Transactions.Add(transactions);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TransactionsExists(transactions.TransactionID))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTransactions", new { id = transactions.TransactionID }, transactions);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTransactions(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Transactions transactions = _context.Transactions.Single(m => m.TransactionID == id);
            if (transactions == null)
            {
                return HttpNotFound();
            }

            _context.Transactions.Remove(transactions);
            _context.SaveChanges();

            return Ok(transactions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionsExists(int id)
        {
            return _context.Transactions.Count(e => e.TransactionID == id) > 0;
        }
    }
}