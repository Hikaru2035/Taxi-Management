using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class TaxiManager
    {
        private  SortedDictionary<int, Taxi> _taxis = new SortedDictionary<int, Taxi>();
        public SortedDictionary<int, Taxi> taxis { get { return _taxis; } }
        
        public SortedDictionary<int,Taxi> GetAllTaxis()
        {
            return taxis;
        }

        public Taxi FindTaxi(int taxiNum)
        {
            if (taxis.ContainsKey(taxiNum)) return taxis[taxiNum];
            return null;
        }

        // create new taxi if that taxi not found in list
        public Taxi CreateTaxi(int taxiNum)
        {
            if (!taxis.ContainsKey(taxiNum)) 
            {
                Taxi t = new Taxi(taxiNum);
                taxis.Add(taxiNum, t);
                return t;
            }
            return taxis[taxiNum];
        }
    }
}
