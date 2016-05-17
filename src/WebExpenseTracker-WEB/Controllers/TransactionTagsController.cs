using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using WebExpenseTracker_WEB.EF;

namespace WebExpenseTracker_WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/TransactionTags")]
    public class TransactionTagsController : Controller
    {
        private WebExpenseTrackerContext _context;

        public TransactionTagsController(WebExpenseTrackerContext context)
        {
            _context = context;
        }

        // GET: api/TransactionTags
        [HttpGet]
        public IEnumerable<TransactionTags> GetTransactionTags()
        {
            return _context.TransactionTags;
        }

        // GET: api/TransactionTags/5
        [HttpGet("{id}", Name = "GetTransactionTags")]
        public IActionResult GetTransactionTags([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            TransactionTags transactionTags = _context.TransactionTags.Single(m => m.TransactionTagID == id);

            if (transactionTags == null)
            {
                return HttpNotFound();
            }

            return Ok(transactionTags);
        }

        // PUT: api/TransactionTags/5
        [HttpPut("{id}")]
        public IActionResult PutTransactionTags(int id, [FromBody] TransactionTags transactionTags)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != transactionTags.TransactionTagID)
            {
                return HttpBadRequest();
            }

            _context.Entry(transactionTags).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionTagsExists(id))
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

        // POST: api/TransactionTags
        [HttpPost]
        public IActionResult PostTransactionTags([FromBody] TransactionTags transactionTags)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.TransactionTags.Add(transactionTags);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TransactionTagsExists(transactionTags.TransactionTagID))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTransactionTags", new { id = transactionTags.TransactionTagID }, transactionTags);
        }

        // DELETE: api/TransactionTags/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTransactionTags(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            TransactionTags transactionTags = _context.TransactionTags.Single(m => m.TransactionTagID == id);
            if (transactionTags == null)
            {
                return HttpNotFound();
            }

            _context.TransactionTags.Remove(transactionTags);
            _context.SaveChanges();

            return Ok(transactionTags);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionTagsExists(int id)
        {
            return _context.TransactionTags.Count(e => e.TransactionTagID == id) > 0;
        }
    }
}