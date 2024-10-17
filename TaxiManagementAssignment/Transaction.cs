using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public abstract class Transaction
    {
        public DateTime TransactionDatetime;
        public string TransactionType;

        public Transaction(string type, DateTime dt)
        {
            TransactionType = type;
            TransactionDatetime = dt;
        }

        public DateTime GetTransactionDatetime()
        {
            return TransactionDatetime;
        }

        public string GetTransactionType()
        {
            return TransactionType;
        }

        public string GetActualDateType()
        {
            DateTime now = DateTime.Now;
            string dateStr = now.ToString("dd/MM/yyyy HH:mm");
            return dateStr;
        }
        public override string ToString()
        {
            return $"{GetActualDateType()} Transaction Type: {TransactionType}, Transaction Datetime: {TransactionDatetime}";
        }
    }  
}
