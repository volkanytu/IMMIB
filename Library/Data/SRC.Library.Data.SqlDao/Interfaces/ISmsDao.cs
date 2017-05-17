using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Data.SqlDao.Interfaces
{
    public interface ISmsDao
    {
        void UpdateSmsResult(SmsEnt sms);
    }
}
