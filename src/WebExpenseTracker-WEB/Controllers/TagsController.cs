using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using WebExpenseTracker_WEB.EF;

namespace WebExpenseTracker_WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/Tags")]
    public class TagsController : Controller
    {
        private WebExpenseTrackerContext _context;

        public TagsController(WebExpenseTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        public IEnumerable<Tags> GetTags()
        {
            return _context.Tags;
        }

        // GET: api/Tags/5
        [HttpGet("{id}", Name = "GetTags")]
        public IActionResult GetTags([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Tags tags = _context.Tags.Single(m => m.TagID == id);

            if (tags == null)
            {
                return HttpNotFound();
            }

            return Ok(tags);
        }

        // PUT: api/Tags/5
        [HttpPut("{id}")]
        public IActionResult PutTags(int id, [FromBody] Tags tags)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != tags.TagID)
            {
                return HttpBadRequest();
            }

            _context.Entry(tags).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagsExists(id))
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

        // POST: api/Tags
        [HttpPost]
        public IActionResult PostTags([FromBody] Tags tags)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Tags.Add(tags);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TagsExists(tags.TagID))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTags", new { id = tags.TagID }, tags);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTags(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Tags tags = _context.Tags.Single(m => m.TagID == id);
            if (tags == null)
            {
                return HttpNotFound();
            }

            _context.Tags.Remove(tags);
            _context.SaveChanges();

            return Ok(tags);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TagsExists(int id)
        {
            return _context.Tags.Count(e => e.TagID == id) > 0;
        }
    }
}