using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotelManagement.Utility
{
    public class IdGenerator
    {
        /* generate next ID function when insert data to database
         * prefix: ST, U, N
         * previousID: last ID in table of database
         * addTime: attach 2 last number of year (20, 19, 21...) to ID (R20, ST20....)
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