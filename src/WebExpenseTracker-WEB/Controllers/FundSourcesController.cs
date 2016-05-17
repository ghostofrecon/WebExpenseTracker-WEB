using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using WebExpenseTracker_WEB.EF;

namespace WebExpenseTracker_WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/FundSources")]
    public class FundSourcesController : Controller
    {
        private WebExpenseTrackerContext _context;

        public FundSourcesController(WebExpenseTrackerContext context)
        {
            _context = context;
        }

        // GET: api/FundSources
        [HttpGet]
        public IEnumerable<FundSources> GetFundSources()
        {
            return _context.FundSources;
        }

        // GET: api/FundSources/5
        [HttpGet("{id}", Name = "GetFundSources")]
        public IActionResult GetFundSources([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            FundSources fundSources = _context.FundSources.Single(m => m.FundSourceID == id);

            if (fundSources == null)
            {
                return HttpNotFound();
            }

            return Ok(fundSources);
        }

        // PUT: api/FundSources/5
        [HttpPut("{id}")]
        public IActionResult PutFundSources(int id, [FromBody] FundSources fundSources)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != fundSources.FundSourceID)
            {
                return HttpBadRequest();
            }

            _context.Entry(fundSources).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundSourcesExists(id))
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

        // POST: api/FundSources
        [HttpPost]
        public IActionResult PostFundSources([FromBody] FundSources fundSources)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.FundSources.Add(fundSources);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FundSourcesExists(fundSources.FundSourceID))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetFundSources", new { id = fundSources.FundSourceID }, fundSources);
        }

        // DELETE: api/FundSources/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFundSources(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            FundSources fundSources = _context.FundSources.Single(m => m.FundSourceID == id);
            if (fundSources == null)
            {
                return HttpNotFound();
            }

            _context.FundSources.Remove(fundSources);
            _context.SaveChanges();

            return Ok(fundSources);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FundSourcesExists(int id)
        {
            return _context.FundSources.Count(e => e.FundSourceID == id) > 0;
        }
    }
}