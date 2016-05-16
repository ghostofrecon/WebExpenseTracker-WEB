using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExpenseTracker_WEB.Models.API.TransactionTag
{
    public class TransactionTag
    {
        public int TransactionTagID { get; set; }
        public int TagID { get; set; }
        public int TransactionID { get; set; }
    }
}
