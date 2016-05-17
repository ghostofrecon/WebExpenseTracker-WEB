using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebExpenseTracker_DataAccess
{
    public class WebExpenseTrackerDa : IWebExpenseTrackerDa
    {
        public TransactionDA TransactionDa { get; set; }
        public TagDA TagDa { get; set; }
        public FundSourceDA FundSourceDa { get; set; }

        public WebExpenseTrackerDa(string connectionString)
        {
            FundSourceDa = new FundSourceDA(connectionString);
            TagDa = new TagDA(connectionString);
            TransactionDa = new TransactionDA(connectionString);
        }

        
    }
}
