using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoice
{
    public class RideRepo
    {
        public Dictionary<string, List<Ride>> rideRepo;

        public RideRepo()
        {
            rideRepo = new Dictionary<string, List<Ride>>();
        }
        public void AddRideRepo(string userid, Ride rides)
        {
            if (rideRepo.ContainsKey(userid))
            {
                rideRepo[userid].Add(rides);

            }
            else
            {
                rideRepo.Add(userid, new List<Ride>());
                rideRepo[userid].Add(rides);
            }
        }
        public List<Ride> returnListByUserId(string userid)
        {
            if (rideRepo.ContainsKey(userid))
            {
                return rideRepo[userid];
            }
            else
                throw new CabInvoiceExceptions(CabInvoiceExceptions.ExceptionType.Invaild_User_Id, "invaid user id");

        }

    }
}
