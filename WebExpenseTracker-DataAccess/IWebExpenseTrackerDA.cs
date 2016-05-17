using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpenseTracker_DataAccess
{
    public interface IWebExpenseTrackerDa
    {
        TransactionDA TransactionDa { get; set; }
        TagDA TagDa { get; set; }
        FundSourceDA FundSourceDa { get; set; }

    }
}
