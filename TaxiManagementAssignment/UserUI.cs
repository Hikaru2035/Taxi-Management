using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class UserUI
    {
        public RankManager rankMgr;
        public TaxiManager taxiMgr;
        public TransactionManager transactionMgr;

        public UserUI(RankManager mgr, TaxiManager taxiMgr, TransactionManager transactionMgr)
        {
            rankMgr = mgr;
            this.taxiMgr = taxiMgr;
            this.transactionMgr = transactionMgr;
        }

        public List<string> TaxiJoinsRank(int taxiNum, int rankId)
        {
            List<string> list = new List<string>();

            // find taxi, if taxi not found, create new taxi
            Taxi t = taxiMgr.FindTaxi(taxiNum);
            if (t == null)
            {
                t = taxiMgr.CreateTaxi(taxiNum);
            }

            // add taxi to rank
            bool addToRank = rankMgr.AddTaxiToRank(t, rankId);
            if (addToRank)
            {
                list.Add($"Taxi {taxiNum} has joined rank {rankId}.");
                transactionMgr.RecordJoin(taxiNum, rankId);
            }
            else
            {
                list.Add($"Taxi {taxiNum} has not joined rank {rankId}.");
            }


            return list;
        }

        public List<string> TaxiLeavesRank(int rankId, string destination, double agreedPrice)
        {
            List<string> list = new List<string>();

            // front taxi found in rank take fare
            Taxi t = rankMgr.FrontTaxiInRankTakesFare(rankId, destination, agreedPrice);

            // if taxi found, taxi leave rank
            if (t != null)
            {
                transactionMgr.RecordLeave(rankId, t);
                list.Add($"Taxi {t.Number} has left rank {rankId} to take a fare to {destination} for £{agreedPrice}.");
                t.AddFare(destination, agreedPrice);
            }
            else
            {
                list.Add($"Taxi has not left rank {rankId}.");
            }

            return list;
        }

        public List<string> TaxiDropsFare(int taxiNum, bool pricePaid)
        {
            List<string> list = new List<string>();

            // find taxi in list, taxi drop fare
            Taxi taxi = taxiMgr.FindTaxi(taxiNum);
            taxi.DropFare(pricePaid);

            if (taxi.Rank != null)
            {
                list.Add($"Taxi {taxiNum} has not dropped its fare.");
            }
            else // check price 
            {
                if (pricePaid)
                {
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                    list.Add($"Taxi {taxiNum} has dropped its fare and the price was paid.");
                }
                else
                {
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                    list.Add($"Taxi {taxiNum} has dropped its fare and the price was not paid.");
                }
            }
            return list;
        }

        public List<string> ViewTaxiLocations
            ()
        {
            List<string> list = new List<string>();

            list.Add("Taxi locations");
            list.Add("==============");

            // list all taxi
            IEnumerable<Taxi> allTaxis = taxiMgr.GetAllTaxis().Values;
            if (!taxiMgr.GetAllTaxis().Any())
            {
                list.Add("No taxis");
            }
            else // taxi found return location
            {
                foreach (Taxi t in allTaxis)
                {
                    if (t.Location == "on the road")
                    {
                        if (t.CurrentFare == 0)
                        {
                            list.Add($"Taxi {t.Number} is {t.Location}");
                        }
                        else
                        {
                            list.Add($"Taxi {t.Number} is {t.Location} to {t.Destination}");
                        }
                    }
                    else
                    {
                        list.Add($"Taxi {t.Number} is in rank {t.Rank.Id}");
                    }
                }
            }

            return list;
        }

        public List<string> ViewFinancialReport()
        {
            List <string> list = new List<string>();

            list.Add("Financial report");
            list.Add("================");

            IEnumerable<Taxi> allTaxis = taxiMgr.GetAllTaxis().Values;
            if (!taxiMgr.GetAllTaxis().Any())
            {
                list.Add("No taxis, so no money taken");
            }
            else
            {
                foreach (Taxi t in allTaxis)
                {
                    if (t.Location == "on the road")
                    {
                        if (t.CurrentFare == 0)
                        {
                            list.Add($"Taxi {t.Number}      {t.TotalMoneyPaid.ToString("F2")}");
                        }
                        else
                        {
                            list.Add($"Taxi {t.Number}      {t.TotalMoneyPaid.ToString("F2")}");
                        }
                    }
                    else
                    {
                        list.Add($"Taxi {t.Number}      {t.TotalMoneyPaid.ToString("F2")}");
                    }
                }
                double totalMoney = allTaxis.Sum(t => t.TotalMoneyPaid);
                list.Add("           ======");
                list.Add($"Total:       {totalMoney.ToString("F2")}");
                list.Add("           ======");
            }
                return list;
        }

        public List<string> ViewTransactionLog()
        {
            List<string> list = new List<string>();

            list.Add("Transaction report");
            list.Add("==================");

            IEnumerable<Transaction> allTransaction = transactionMgr.TransactionList;
            if (!allTransaction.Any())
            {
                list.Add("No transactions");
            }
            else
            {
                foreach (Transaction t in allTransaction)
                {
                    list.Add($"{t}");
                }
            }
            return list;    
        }
    }
}
