using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyRequestDomain.Entity.Enums
{
    public enum BuyRequestStatus
    {
        RECEIVED = 1,
        WAITING_DELIVERY = 2,
        WAITING_DOWNLOAD = 3,
        FINISHED = 4
    }
}