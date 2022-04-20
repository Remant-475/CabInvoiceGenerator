using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoice
{
    public  class CabInvoiceExceptions : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            Invalid_Distance,Invalid_Time, Invalid_Totalfare,
            Invaild_User_Id, 
        }
        public CabInvoiceExceptions(ExceptionType type,string message) : base(message)
        {
            this.type = type;
        }
    }
}
