using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExpenseTracker_WEB.Models.API.Transaction
{
    public class TransactionUpdateModel
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDts { get; set; }
        public string TransactionUserId { get; set; }
        public bool TransactionIsCredit { get; set; }
        public float TransactionAmount { get; set; }
        public int TransactionFundSourceId { get; set; }
        public bool TransactionDeleted { get; set; }
    }
}
