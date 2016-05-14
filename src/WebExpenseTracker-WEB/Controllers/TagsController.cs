using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebExpenseTracker_WEB.Models.API.Tags;
using WebExpenseTracker_WEB.EF;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebExpenseTracker_WEB.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        // GET: api/tags
        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            var context = new WebExpenseTrackerContext();
            return context.Tags.Where(x => x.TagUserID == User.GetUserId()).Select(x => new Tag { TagId = x.TagID, TagName = x.TagName }).ToList();
        }

        // GET api/tags/5
        [HttpGet("{id}")]
        public Tag Get(int id)
        {
            var context = new WebExpenseTrackerContext();
            if (!context.Tags.Any(x => x.TagID == id && x.TagUserID == User.GetUserId()))
            {
                HttpContext.Response.StatusCode = 404;
                return null;
            }
            var tag = context.Tags.Single(x => x.TagID == id && x.TagUserID == User.GetUserId());
            return new Tag { TagId = tag.TagID, TagName = tag.TagName };
        }

        // POST api/tags
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/tags/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tags/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
