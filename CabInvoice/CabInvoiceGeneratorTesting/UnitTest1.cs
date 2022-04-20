using NUnit.Framework;
using CabInvoice;
using System.Collections.Generic;

namespace CabInvoiceGeneratorTesting
{
    public class Tests
    {
        InvoiceGenerator invoiceNormalRide;
        RideRepo rideRepo;

        [SetUp]
        public void Setup()
        {
            invoiceNormalRide = new InvoiceGenerator();
            rideRepo = new RideRepo();
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
        //UC4.1- Check fare of user using valid UserID
        [Test]
        public void ValidUserIdInvoice()
        {
            Ride rides_1 = new Ride(2, 2);
            Ride rides_2 = new Ride(2, 1);

            rideRepo.AddRideRepo("abc", rides_1);
            rideRepo.AddRideRepo("abc", rides_2);

            Assert.AreEqual(43.0d, invoiceNormalRide.InhancedInvoice(rideRepo.returnListByUserId("abc")));
            Assert.AreEqual(21.5d, invoiceNormalRide.averagePerRide);
            Assert.AreEqual(2, invoiceNormalRide.numberOfRides);
        }
        //UC 4.2 -  Invalid User Id Throws Exception
        [Test]
        public void InvaidUserIdInvioce()
        {
            Ride rides_1 = new Ride(3, 2);
            Ride rides_2 = new Ride(2, 1);

            rideRepo.AddRideRepo("abc", rides_1);
            rideRepo.AddRideRepo("abc", rides_2);

            var Exception = Assert.Throws<CabInvoiceExceptions>(() => invoiceNormalRide.TotalFareForMultipleRide(rideRepo.returnListByUserId("xyz")));
            Assert.AreEqual(Exception.type, CabInvoiceExceptions.ExceptionType.Invaild_User_Id);

        }
        //TC 5.1 - Total fare for Premium ride

        [Test]
        [TestCase(8, 5)]
        public void Given_DistanceAndTime_CalculatePremiumFare(double distance, double time)
        {
            Ride rides = new Ride(distance, time);
            int expected = 130;
            Assert.AreEqual(expected, invoiceNormalRide.TotalFareForPremiumSingleRide(rides));
        }

        //  TC 5.2 -  Invalid Distance Throws Exception

        [Test]
        public void Given_InvalidDistance_ThrowsException()
        {
            Ride rides = new Ride(-1, 4);

            CabInvoiceExceptions cabInvoiceException = Assert.Throws<CabInvoiceExceptions>(() => invoiceNormalRide.TotalFareForSingleRide(rides));
            Assert.AreEqual(cabInvoiceException.type, CabInvoiceExceptions.ExceptionType.Invalid_Distance);

        }

        // TC 5.3 - The Invalid Time Throws Exception
        [Test]
        public void Given_InvalidTime_ThrowsException()
        {
            Ride rides = new Ride(2, -5);
            CabInvoiceExceptions cabInvoiceException = Assert.Throws<CabInvoiceExceptions>(() => invoiceNormalRide.TotalFareForSingleRide(rides));
            Assert.AreEqual(cabInvoiceException.type, CabInvoiceExceptions.ExceptionType.Invalid_Time);

        }

        // TC 5.4 Total fare for Premium Multiple rides

        [Test]
        public void Given_DistanceAndTime_CalculteFareForPremiumMultipleRide()
        {
            Ride rideOne = new Ride(8, 5);
            Ride rideTwo = new Ride(7, 6);
            List<Ride> rides = new List<Ride>();
            rides.Add(rideOne);
            rides.Add(rideTwo);

            Assert.AreEqual(247.0d, invoiceNormalRide.TotalFareForPremiumMultipleRide(rides));
        }

    }
}
    
