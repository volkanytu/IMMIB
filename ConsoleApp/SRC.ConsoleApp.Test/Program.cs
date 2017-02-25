using SRC.Plugins.CrmPlugin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.ConsoleApp.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            PluginDebug pd = new PluginDebug();
            pd.Test(TaskType.EDUCATION, PluginOperation.SET_STATE, "new_education", Guid.Parse("E7DCAAC8-39F1-E611-80D6-005056A507B1"));
        }
    }
}
