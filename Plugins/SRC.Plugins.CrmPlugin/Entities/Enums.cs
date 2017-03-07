using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Plugins.CrmPlugin.Entities
{
    public class Enums
    {
    }

    public enum TaskType
    {
        EDUCATION,
        EDUCATION_ATTENDANCE
    }

    public enum PluginOperation
    {
        PRE_CREATE,
        POST_CREATE,
        PRE_UPDATE,
        POST_UPDATE,
        PRE_DELETE,
        POST_DELETE,
        SET_STATE
    }
}
