using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebExpenseTracker_WEB.EF;
using System.Security.Claims;
using WebExpenseTracker_WEB.Models.API.FundSource;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebExpenseTracker_WEB.Controllers
{
    [Route("api/[controller]")]
    public class FundSourcesController : Controller
    {
        // GET: api/fundsources
        [HttpGet]
        public IEnumerable<FundSource> Get()
        {
            var context = new WebExpenseTrackerContext();
            return context.FundSources
                .Where(x => x.FundSourceUserID == User.GetUserId())
                .Select(x => new FundSource
                {
                    FundSourceID = x.FundSourceID,
                    FundSourceName = x.FundSourceName,
                    FundSourceUserID = x.FundSourceUserID,
                    FundSourceDeleted = x.FundSourceDeleted,
                    FundSourceDTS = x.FundSourceDTS
                });
        }

        // GET api/fundsources/5
        [HttpGet("{id}")]
        public FundSource Get(int id)
        {
            var context = new WebExpenseTrackerContext();
            if (!context.FundSources.Any(x => x.FundSourceUserID == User.GetUserId() && x.FundSourceID == id && x.FundSourceDeleted == false))
            {
                HttpContext.Response.StatusCode = 404;
                return null;
            }
            return context.FundSources.Select(x => new FundSource {FundSourceID = x.FundSourceID, FundSourceName = x.FundSourceName }).Single(x => x.FundSourceID == id);
        }

        // POST api/fundsources
        [HttpPost]
        public void Post([FromBody] FundSource value)
        {
            var context = new WebExpenseTrackerContext();
            if (context.FundSources.Any(x => x.FundSourceName == value.FundSourceName && x.FundSourceUserID == User.GetUserId()))
            {
                HttpContext.Response.StatusCode = 409;
                return;
            }
            var newFS = new FundSources
            {
                FundSourceName = value.FundSourceName,
                FundSourceDTS = DateTime.Now,
                FundSourceDeleted = false,
                FundSourceUserID = User.GetUserId()
            };
            context.FundSources.Add(newFS);
            context.SaveChanges();
        }

        // PUT api/fundsources/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]FundSource value)
        {
            var context = new WebExpenseTrackerContext();
            if (!context.FundSources.Any(x => x.FundSourceID == id && x.FundSourceUserID == User.GetUserId()))
            {
                HttpContext.Response.StatusCode = 404;
                return;
            }
            var oldFS = context.FundSources.Single(x => x.FundSourceID == id);
            oldFS.FundSourceName = value.FundSourceName;
            context.SaveChanges();
        }

        // DELETE api/fundsources/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
