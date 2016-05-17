namespace WebExpenseTracker_DataAccess
{
    public class TransactionDA
    {
        private string connectionString;

        public TransactionDA(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}