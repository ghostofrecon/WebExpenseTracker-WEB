using System;
using System.Collections.Generic;

namespace WebExpenseTracker_WEB.EF
{
    public partial class FundSources
    {
        public FundSources()
        {
            Transactions = new HashSet<Transactions>();
        }

        public int FundSourceID { get; set; }
        public bool FundSourceDeleted { get; set; }
        public DateTime FundSourceDTS { get; set; }
        public string FundSourceName { get; set; }
        public string FundSourceUserID { get; set; }

        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
