using NUnit.Framework;
using CabInvoice;

namespace CabInvoiceGeneratorTesting
{
    public class Tests
    {
        InvoiceGenerator invoicegeneratorNormalRide;

        [SetUp]
        public void Setup()
        {
            invoicegeneratorNormalRide = new InvoiceGenerator();
        }
        /// UC 1- Total Fare for Single Ride
        [Test]
        [TestCase(5, 3)]

        public void GivenTimeAndDistance_CalculateFare(double distane, double time)
        {
            Ride rides = new Ride(distane, time);
            int expected = 53;
            Assert.AreEqual(expected, invoicegeneratorNormalRide.TotalFareForSingleRide(rides));
        }
        /// TC1.1 - Check for Invalid Distance
        [Test]
        public void ForInvaidDistance()
        {
            Ride rides = new Ride(-4, 6);
            CabInvoiceExceptions cabInvoiceException = Assert.Throws<CabInvoiceExceptions>(() => invoicegeneratorNormalRide.TotalFareForSingleRide(rides));
            Assert.AreEqual(cabInvoiceException.type, CabInvoiceExceptions.ExceptionType.Invalid_Distance);
        }
        /// TC1.2- Check for Invalid Time
        [Test]
        public void ForInvaidTime()
        {
            Ride rides = new Ride(4, -6);
            CabInvoiceExceptions cabInvoiceException = Assert.Throws<CabInvoiceExceptions>(() => invoicegeneratorNormalRide.TotalFareForSingleRide(rides));
            Assert.AreEqual(cabInvoiceException.type, CabInvoiceExceptions.ExceptionType.Invalid_Time);
        }



    }
}