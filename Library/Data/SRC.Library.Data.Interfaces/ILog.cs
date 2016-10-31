using SRC.Library.Entities.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRC.Library.Data.Interfaces
{
    public interface ILog
    {
        void Log(LogEntity logEntity);
    }
}
