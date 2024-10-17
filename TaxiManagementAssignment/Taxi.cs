using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TaxiManagementAssignment
{
    public class Taxi
    {
        private double currentFare;
        private string destination;
        private double totalMoneyPaid;

        public int Number;
        public double CurrentFare { get { return currentFare; } }
        public string Destination { get { return destination; } }
        public double TotalMoneyPaid { get { return totalMoneyPaid; } }

        public string Location;
        public static string IN_RANK = "in rank";
        public static string ON_ROAD = "on the road";

        private Rank rank;
        public Rank Rank { get { return rank; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Rank cannot be null");
                }
                if (!string.IsNullOrEmpty(destination))
                {
                    throw new Exception("Cannot join rank if fare has not been dropped");
                }
                rank = value;
                Location = IN_RANK;
            }
        }

        public bool GetDestination()
        {
            return !string.IsNullOrEmpty(Destination);
        }

        // Set defalt value for new taxi 
        public Taxi(int num)    
        {
            Number = num;
            currentFare = 0;
            destination = string.Empty;
            Location = ON_ROAD;
            totalMoneyPaid = 0;
        }
       
        // Add price and destination for choosen taxi
        public Taxi AddFare (string destinationX, double agreedPrice)
        {
            destination = destinationX;
            currentFare = agreedPrice;
            Location = ON_ROAD;
            rank = null;
            return this; // return chosen taxi
        }
        
        // Set value when taxi drop fare
        public void DropFare (bool priceWasPaid)
        {
            if (priceWasPaid)
            {
                destination = string.Empty;
                totalMoneyPaid += CurrentFare;
                currentFare = 0;
                Location = ON_ROAD;
            }
            else
            {
                totalMoneyPaid += 0;
            }   
        }
    }
}
