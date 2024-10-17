using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class DropTransaction : Transaction
    {
        private int taxiNum;
        private bool priceWaspaid;
        public DropTransaction(DateTime TransactionDatetime, int taxiNum, bool priceWaspaid) : base("Drop fare", TransactionDatetime)
        {
            this.TransactionDatetime = TransactionDatetime;
            this.taxiNum = taxiNum;
            this.priceWaspaid = priceWaspaid;
        }
        public override string ToString()
        {
            if (priceWaspaid)
            {
                return $"{GetActualDateType()} {TransactionType} - Taxi {taxiNum}, price was paid";
            }
            else
            {
                return $"{GetActualDateType()} {TransactionType} - Taxi {taxiNum}, price was not paid";
            }

        }
    }
}
