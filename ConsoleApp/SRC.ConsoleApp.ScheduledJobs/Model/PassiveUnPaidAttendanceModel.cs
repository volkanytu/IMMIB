using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.ConsoleApp.ScheduledJobs.Model
{
    public class PassiveUnPaidAttendanceModel
    {
        public string RemainDay { get; set; }

        public int RemainDayValue
        {
            get
            {
                return int.Parse(this.RemainDay);
            }
        }
    }
}
