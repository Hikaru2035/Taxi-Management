using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class LeaveTransaction : Transaction
    {
        private string Destionation;
        private double CurrentFare;
        private Taxi taxi;
        private int rankId;

        public LeaveTransaction(DateTime TransactionDatetime, int rankId, Taxi t) : base("Leave", TransactionDatetime)
        {
            this.TransactionDatetime = TransactionDatetime;
            this.rankId = rankId;
            taxi = t;
            Destionation = t.Destination;
            CurrentFare = t.CurrentFare;
        }


        public override string ToString()
        {
            return $"{GetActualDateType()} {TransactionType}     - Taxi {taxi.Number} from rank {rankId} to {Destionation} for £{CurrentFare}";

        }
    }
}
