using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CustomEntities
{
    public class ContactAttendanceSummary
    {
        public EntityReferenceWrapper Contact { get; set; }
        public int WaitingPaymentCount { get; set; }
        public int JoinedCount { get; set; }
        public int ConfirmedCount { get; set; }
    }
}
