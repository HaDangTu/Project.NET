using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MotelManagement.Utility
{
    public class DebugLog
    {
        public static void Write(object log)
        {
            Debug.WriteLine(log);
        }
    }
}