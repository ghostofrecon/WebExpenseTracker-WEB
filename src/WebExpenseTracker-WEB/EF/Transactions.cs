using System;
using System.Collections.Generic;

namespace WebExpenseTracker_WEB.EF
{
    public partial class Transactions
    {
        public Transactions()
        {
            TransactionTags = new HashSet<TransactionTags>();
        }

        public int TransactionID { get; set; }
        public float TransactionAmount { get; set; }
        public bool TransactionDeleted { get; set; }
        public DateTime TransactionDTS { get; set; }
        public int TransactionFundSourceID { get; set; }
        public bool TransactionIsCredit { get; set; }
        public string TransactionUserID { get; set; }

        public virtual ICollection<TransactionTags> TransactionTags { get; set; }
        public virtual FundSources TransactionFundSource { get; set; }
        public virtual AspNetUsers TransactionUser { get; set; }
    }
}
