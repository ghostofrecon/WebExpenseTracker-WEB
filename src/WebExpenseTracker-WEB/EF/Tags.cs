using System;
using System.Collections.Generic;

namespace WebExpenseTracker_WEB.EF
{
    public partial class Tags
    {
        public int TagID { get; set; }
        public string TagName { get; set; }
        public string TagUserID { get; set; }

        public virtual TransactionTags TransactionTags { get; set; }
        public virtual AspNetUsers TagUser { get; set; }
    }
}
