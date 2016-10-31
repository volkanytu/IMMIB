using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Common
{
    public static class Utils
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCallerMethod()
        {
            string returnValue = null;

            try
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(2);

                returnValue = sf.GetMethod().Name;
            }
            catch (Exception ex)
            {

            }

            return returnValue;
        }
    }
}
