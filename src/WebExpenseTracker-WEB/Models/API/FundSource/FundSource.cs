using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExpenseTracker_WEB.Models.API.FundSource
{
    public class FundSource
    {
        public int FundSourceID { get; set; }
        public DateTime FundSourceDTS { get; set; }
        public string FundSourceName { get; set; }
        public string FundSourceUserID { get; set; }
        public bool FundSourceDeleted { get; set; }
    }
}
