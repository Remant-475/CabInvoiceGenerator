using NUnit.Framework;
using CabInvoice;
using System.Collections.Generic;

namespace CabInvoiceGeneratorTesting
{
    public class Tests
    {
        InvoiceGenerator invoiceNormalRide;

        [SetUp]
        public void Setup()
        {
            invoiceNormalRide = new InvoiceGenerator();
        }
        /// UC 1- Total Fare for Single Ride
        [Test]
        [TestCase(5, 3)]

        public void GivenTimeAndDistance_CalculateFare(double distane, double time)
        {
            Ride rides = new Ride(distane, time);
            int expected = 53;
            Assert.AreEqual(expected, invoiceNormalRide.TotalFareForSingleRide(rides));
        }
        /// TC1.1 - Check for Invalid Distance
        [Test]
        public void ForInvaidDistance()
        {
            Ride rides = new Ride(-4, 6);
            CabInvoiceExceptions cabInvoiceException = Assert.Throws<CabInvoiceExceptions>(() => invoiceNormalRide.TotalFareForSingleRide(rides));
            Assert.AreEqual(cabInvoiceException.type, CabInvoiceExceptions.ExceptionType.Invalid_Distance);
        }
        /// TC1.2- Check for Invalid Time
        [Test]
        public void ForInvaidTime()
        {
            Ride rides = new Ride(4, -6);
            CabInvoiceExceptions cabInvoiceException = Assert.Throws<CabInvoiceExceptions>(() => invoiceNormalRide.TotalFareForSingleRide(rides));
            Assert.AreEqual(cabInvoiceException.type, CabInvoiceExceptions.ExceptionType.Invalid_Time);
        }
        /// UC2 - Total fare for Multiple rides 
        [Test]
        public void CalculateFareForMultipleRides()
        {
            Ride rides_1 = new Ride(2, 2);
            Ride rides_2 = new Ride(2, 1);
            List<Ride> rides = new List<Ride>();
            rides.Add(rides_1);
            rides.Add(rides_2);
            
            Assert.AreEqual(43.0d, invoiceNormalRide.TotalFareForMultipleRide(rides));

        }
        /// UC-3 Calculte Total number of Rides and Average Fare per Ride
        [Test]
        public void ListOfRidesCalculateFare()
        {
            Ride rides_1 = new Ride(2, 2);
            Ride rides_2 = new Ride(2, 1);

            List<Ride> rides = new List<Ride>();
            rides.Add(rides_1);
            rides.Add(rides_2);

            Assert.AreEqual(43.0d, invoiceNormalRide.InhancedInvoice(rides));
            Assert.AreEqual(21.5d, invoiceNormalRide.averagePerRide);
            Assert.AreEqual(2, invoiceNormalRide.numberOfRides);

        }
    }
}