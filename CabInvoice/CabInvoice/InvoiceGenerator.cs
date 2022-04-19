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
       
        

        public InvoiceGenerator()
        {
            this.price_per_kilometer = 10;
            this.price_per_minute = 1;
            this.minimum_fare = 5;
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
    }
}
