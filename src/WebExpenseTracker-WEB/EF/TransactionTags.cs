using System;
using System.Collections.Generic;

namespace WebExpenseTracker_WEB.EF
{
    public partial class TransactionTags
    {
        public int TransactionTagID { get; set; }
        public int TagID { get; set; }
        public int TransactionID { get; set; }

        public virtual Transactions Transaction { get; set; }
        public virtual Tags TransactionTag { get; set; }
    }
}
