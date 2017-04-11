using SRC.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.WindowsService.GenericService.ServiceLibs.Test.TestTasks
{
    public class TestTask : ITestTask
    {
        public TestTask()
        {

        }

        public void Process()
        {
            FileLog.WriteToFile("Test task Process is fired!", string.Concat(Globals.FileLogPath, "test.txt"));
        }
    }
}
