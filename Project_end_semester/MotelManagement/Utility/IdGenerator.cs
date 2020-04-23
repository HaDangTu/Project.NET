using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotelManagement.Utility
{
    public class IdGenerator
    {
        /* tạo ra mã ID tiếp theo 
         * prefix: tiền tố vd R, ST, H...
         * previousID: ID của item cuối cùng trong mảng
         * addTime: thêm 2 số cuối của năm (20, 19, 21...) vào tiền tố của id (R20, ST20....)
         * return next ID
         */
        public static string generateNextID(string prefix, string previousID, bool addTime)
        {
            if (addTime)
            {
                string year = DateTime.Now.Year.ToString().Substring(2, 2);
                prefix = prefix + year;

                string oldPrefix = previousID.Substring(0, prefix.Length);
                previousID = previousID.Replace(oldPrefix, prefix);
            }

            string postfix = previousID.Substring(previousID.IndexOf(prefix) + prefix.Length);

            string oldID = (int.Parse(postfix)).ToString();
            string newID = (int.Parse(oldID) + 1).ToString();

            if (newID.Length > oldID.Length) oldID = oldID.Insert(0, "0");

            previousID = previousID.Replace(oldID, newID);

            return previousID;
        }
    }
}