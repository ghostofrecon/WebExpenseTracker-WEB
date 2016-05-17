using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExpenseTracker_WEB;
using WebExpenseTracker_WEB.Models.API.Tags;

namespace WebExpenseTracker_WEB.Models.API.Transaction
{
    public class TransactionAddModel
    {
        public DateTime TransactionDts { get; set; }
        public string TransactionUserId { get; set; }
        public bool TransactionIsCredit { get; set; }
        public float TransactionAmount { get; set; }
        public int TransactionFundSourceId { get; set; }
        public bool TransactionDeleted { get; set; }
        public IEnumerable<Tag> TransactionTags { get; set; }

        public TransactionAddModel()
        {
            TransactionTags = new List<Tag>();
        }
    }
}
