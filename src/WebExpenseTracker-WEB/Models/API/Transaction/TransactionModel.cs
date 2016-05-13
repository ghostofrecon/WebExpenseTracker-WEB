using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExpenseTracker_WEB.Models.API.Tags;

namespace WebExpenseTracker_WEB.Models.API.Transaction
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDts { get; set; }
        public string TransactionUserId { get; set; }
        public string TransactionUserName { get; set; }
        public bool TransactionIsCredit { get; set; }
        public float TransactionAmount { get; set; }
        public int TransactionFundSourceId { get; set; }
        public string TransactionFundSourceName { get; set; }
        public IEnumerable<Tag> TransactionTags { get; set; }

        public TransactionModel()
        {
            TransactionTags = new List<Tag>();
        }

    }
}
