using System;
using System.Collections.Generic;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Data.SqlDao.Interfaces
{
    public interface IEducationDao
    {
        List<Education> GetEducations(DateTime startDate, DateTime endDate);
    }
}