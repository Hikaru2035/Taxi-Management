using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
{
    public class Rank
    {
        private int id;
        private int numberOfTaxiSpaces;
        private List<Taxi> taxiSpaces = new List<Taxi>();
        public int Id { get { return id; } }    
        public int NumberOfTaxiSpaces { get { return numberOfTaxiSpaces; } }
        public List<Taxi> TaxiSpaces { get { return taxiSpaces; } }

        public Rank(int idX , int numberOfTaxiSpacesX ) 
        {
            id = idX;
            numberOfTaxiSpaces = numberOfTaxiSpacesX;
        }

        //Add a taxi to the rank if there have space
        public bool AddTaxi(Taxi t)
        {
            if (TaxiSpaces.Count < NumberOfTaxiSpaces)
            {
                //Assigns the current rank to the taxi
                t.Rank = this;
                TaxiSpaces.Add(t);
                return true;
            }
            return false;
        }

        //The front taxi in the rank to take a fare
        public Taxi FrontTaxiTakesFare(string destination, double agreedPrice)
        {
            if (TaxiSpaces.Count > 0)
            {
                Taxi FirstTaxi = TaxiSpaces[0];
                TaxiSpaces.Remove(TaxiSpaces[0]);
                FirstTaxi.AddFare(destination, agreedPrice);
                return FirstTaxi;
            }
            else
            {
                // Return null that there are no taxis available
                return null;
            }
        }


    }
}
