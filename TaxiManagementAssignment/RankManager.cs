using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class RankManager
    {
        private Dictionary<int, Rank> _ranks = new Dictionary<int, Rank>();
        public Dictionary<int, Rank> Ranks { get { return _ranks; } }


        public Rank FindRank(int rankId)
        {
            if (_ranks.ContainsKey(rankId))
            {
                // If the rank already exists in the dictionary, return it
                return _ranks[rankId];
            }
            else
            {
                // If the rank doesn't exist, create a new one and add it to the dictionary
                Rank newRank = null;
                switch (rankId)
                {
                    case 1:
                        newRank = new Rank(rankId, 5);
                        break;
                    case 2:
                        newRank = new Rank(rankId, 2);
                        break;
                    case 3:
                        newRank = new Rank(rankId, 4);
                        break;
                    default:
                        break;
                }

                if (newRank != null)
                {
                    _ranks.Add(rankId, newRank);
                }

                return newRank;
            }
        }

        // If rank and destination not null, add taxi to existed rank
        public bool AddTaxiToRank(Taxi t, int rankId)
        {
            if (t.Rank != null) { return false; }
            if (t.GetDestination()) { return false; }

            Rank newRank = FindRank(rankId); // Find exist rank

            if (newRank != null && newRank.TaxiSpaces.Count < newRank.NumberOfTaxiSpaces)
            {
                newRank.AddTaxi(t);
                return true;
            }
            return false; // return when rank not found

        }

        public Taxi FrontTaxiInRankTakesFare(int rankId, string destination, double agreedPrice)
        {
            if (!_ranks.ContainsKey(rankId))
            {
                return null; // taxi in rank, return null
            }

            Rank rank = _ranks[rankId];
            
            foreach (Taxi taxi in rank.TaxiSpaces)
            {
                rank.FrontTaxiTakesFare(destination, agreedPrice);
                return taxi;
            }
            return null;// no taxi in rank    
        }
        
    }
}  
