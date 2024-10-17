using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class JoinTransaction : Transaction
    {
        private readonly int taxiNum;
        private readonly int rankId;

        public int TaxiNum { get { return taxiNum; } }
        public int RankId { get { return rankId; } }

        public JoinTransaction (DateTime TransactionDatetime, int taxiNum, int rankId) : base ("Join", TransactionDatetime)
        {
            this.TransactionDatetime = TransactionDatetime;
            this.taxiNum = taxiNum;
            this.rankId = rankId;
        }
        public override string ToString()
        {
            return $"{GetActualDateType()} {TransactionType}      - Taxi {taxiNum} in rank {rankId}";
        }
    }
}
