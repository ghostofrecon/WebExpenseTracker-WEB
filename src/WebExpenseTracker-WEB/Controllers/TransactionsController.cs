using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebExpenseTracker_WEB.EF;
using WebExpenseTracker_WEB.Models.API.Tags;
using WebExpenseTracker_WEB.Models.API.Transaction;
using WebExpenseTracker_WEB.Models.API.TransactionTag;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebExpenseTracker_WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        // GET: api/transactions
        [HttpGet]
        public IEnumerable<TransactionModel> Get()
        {
            var ret = new List<TransactionModel>();
            //Gets the context
            var context = new WebExpenseTrackerContext();
            //Returns list casted into APIDataModel
            if (context.Transactions.Any(x => x.TransactionUserID == User.GetUserId()))
            {
                var transactions = context.Transactions.Where(x => x.TransactionUserID == User.GetUserId());
                foreach (var trans in transactions)
                {
                    var transactionTags =
                        context.TransactionTag.Where(x => x.TransactionID == trans.TransactionID)
                            .Select(
                                x =>
                                    new TransactionTag
                                    {
                                        TagID = x.TagID,
                                        TransactionID = x.TransactionID,
                                        TransactionTagID = x.TransactionTagID
                                    });
                    var tags = new List<Tag>();
                    foreach (var tt in transactionTags)
                    {
                        tags.Add(context.Tags.Single(x => x.TagID == tt.TagID));
                    }
                    var singleTrans = new TransactionModel
                    {
                        TransactionAmount = trans.TransactionAmount,
                        TransactionDts = trans.TransactionDTS,
                        TransactionFundSourceId = trans.TransactionFundSourceID,
                        TransactionId = trans.TransactionID,
                        TransactionIsCredit = trans.TransactionIsCredit,
                        TransactionUserId = trans.TransactionUserID,
                        TransactionTags = 
                    };
                }
            }
        }

        // GET api/transactions/5
        [HttpGet("{id}")]
        public TransactionModel Get(int id)
        {
            //Gets the context
            var context = new WebExpenseTrackerContext();
            //Gets a single record defined by the ID
            var x = context.Transactions
                .SingleOrDefault(y => y.TransactionUserID == User.GetUserId() && y.TransactionID == id && y.TransactionDeleted == false);
            //Make sure x is a thing
            if (x != null)
            {
                //Returns single record 
                return new TransactionModel
                {
                    TransactionId = x.TransactionID,
                    TransactionAmount = x.TransactionAmount,
                    TransactionDts = x.TransactionDTS,
                    TransactionFundSourceId = x.TransactionFundSourceID,
                    TransactionIsCredit = x.TransactionIsCredit,
                    TransactionTags = x.TransactionTags.Select(y => new Tag { TagId = y.TagID, TagName = context.Tags.Single(z => z.TagID == y.TagID).TagName }).ToList()
                };
            }
            //if x is not a thing, set status code to 404 and return null
            HttpContext.Response.StatusCode = 404;
            return null;
            
        }

        // POST api/transactions
        [HttpPost]
        public int Post([FromBody]TransactionAddModel value)
        {
            var context = new WebExpenseTrackerContext();
            var recordExists = context.FundSources.Any(
                x => x.FundSourceID == value.TransactionFundSourceId && x.FundSourceUserID == User.GetUserId());
            if (!recordExists)
            {
                HttpContext.Response.StatusCode = 409;
                return 0;
            }
            else
            {
                var tagsIDs = value.TransactionTags.Select(x => x.TagId).ToList();
                var tags = (ICollection<Tags>) context.Tags.Where(x => tagsIDs.Contains(x.TagID));
                var t = new Transactions()
                {
                    TransactionAmount = value.TransactionAmount,
                    TransactionDeleted = value.TransactionDeleted,
                    TransactionDTS = DateTime.Now,
                    TransactionFundSourceID = value.TransactionFundSourceId,
                    TransactionIsCredit = value.TransactionIsCredit,
                    TransactionUserID = User.GetUserId(),
                };
                context.Transactions.Add(t);
                context.SaveChanges();
                var id = t.TransactionID;
                context.TransactionTags.AddRange(tags.Select(x => new TransactionTags {TagID = x.TagID, TransactionID = id}));
                context.SaveChanges();
                return id;
            }
        }

        // PUT api/transactions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TransactionUpdateModel value)
        {
            var context = new WebExpenseTrackerContext();
            if (!context.Transactions.Any(x => x.TransactionDeleted == false && x.TransactionID == id))
            {
                HttpContext.Response.StatusCode = 404;
                return;
            }
            var original = context.Transactions.Single(x => x.TransactionID == id);
            original.TransactionAmount = value.TransactionAmount;
            original.TransactionFundSourceID = value.TransactionFundSourceId;
            original.TransactionIsCredit = value.TransactionIsCredit;
        }

        // DELETE api/transactions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var context = new WebExpenseTrackerContext();
            if (!context.Transactions.Any(x => x.TransactionID == id && x.TransactionDeleted == false))
            {
                HttpContext.Response.StatusCode = 404;
                return;
            }
            var trans = context.Transactions.Single(x => x.TransactionID == id);
            trans.TransactionDeleted = true;
            context.SaveChanges();

        }
    }
}
