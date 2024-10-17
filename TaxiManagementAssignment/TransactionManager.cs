using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class TransactionManager
    {
        private List<Transaction> _transactions = new List<Transaction>();
        public List<Transaction> TransactionList { get { return _transactions; } }  

        public List<Transaction> GetAllTransactions()
        {
            return _transactions;
        }

        public void RecordJoin(int taxiNum, int rankId)
        {
            JoinTransaction joinTransaction = new JoinTransaction(DateTime.Now, taxiNum, rankId);

            _transactions.Add(joinTransaction);
        }

        public void RecordDrop(int taxiNum, bool pricePaid)
        {
            DropTransaction dropTransaction = new DropTransaction(DateTime.Now, taxiNum, pricePaid);
            _transactions.Add(dropTransaction);
        }

        public void RecordLeave(int rankId, Taxi t)
        {   
            LeaveTransaction leaveTransaction = new LeaveTransaction(DateTime.Now, rankId, t);
            _transactions.Add(leaveTransaction);
        }
    }
}
