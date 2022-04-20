using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoice
{
    public class InvoiceGenerator
    {
        readonly int price_per_kilometer;
        readonly int price_per_minute;
        readonly int minimum_fare;
        public double total_fare;
        public int numberOfRides;
        public double averagePerRide;
        readonly int premiumPricePerKm;
        readonly int premiumPricePerMin;
        readonly int premiumMinimumFare;


        public InvoiceGenerator()
        {
            this.price_per_kilometer = 10;
            this.price_per_minute = 1;
            this.minimum_fare = 5;
            this.premiumPricePerKm = 15;
            this.premiumPricePerMin = 2;
            this.premiumMinimumFare = 20;
        }


        public double TotalFareForSingleRide(Ride rides)
        {
            if (rides.distance < 0)
            {
                throw new CabInvoiceExceptions(CabInvoiceExceptions.ExceptionType.Invalid_Distance, "Invaid Distance");
            }
            if (rides.time < 0)
            {
                throw new CabInvoiceExceptions(CabInvoiceExceptions.ExceptionType.Invalid_Time, "Invaid Time");
            }
            return Math.Max(minimum_fare, rides.distance * price_per_kilometer + rides.time * price_per_minute);
        }

       // UC-2
        public double TotalFareForMultipleRide(List<Ride> multirides)
        {
            foreach (Ride rides in multirides)
            {
                total_fare += TotalFareForSingleRide(rides);


            }
            return total_fare;
        }
        public double InhancedInvoice(List<Ride> multirides)//uc3
        {
            foreach (Ride rides in multirides)
            {
                total_fare += TotalFareForSingleRide(rides);
                numberOfRides += 1;

            }
            averagePerRide = total_fare / numberOfRides;
            return total_fare;
        }
        public double TotalFareForPremiumSingleRide(Ride rides)
        {
            if (rides.distance < 0)
            {
                throw new CabInvoiceExceptions(CabInvoiceExceptions.ExceptionType.Invalid_Distance, "Invalid Distance");
            }
            if (rides.time < 0)
            {
                throw new CabInvoiceExceptions(CabInvoiceExceptions.ExceptionType.Invalid_Time, "Invaid Time");
            }
            return Math.Max(premiumMinimumFare, rides.distance * premiumPricePerKm + rides.time * premiumPricePerMin);
        }
        public double TotalFareForPremiumMultipleRide(List<Ride> multiride)
        {
            foreach (Ride ride in multiride)
            {
                total_fare += TotalFareForPremiumSingleRide(ride);
                numberOfRides += 1;
            }
            averagePerRide = total_fare / numberOfRides;
            return total_fare;
        }
    }
}
