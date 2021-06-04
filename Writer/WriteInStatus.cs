//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using System;
using System.IO;
using Objects;

namespace Writer
{
    /// <summary>
    /// Class writing status to the list
    /// </summary>
    public class WriteInStatus
    {
        #region BOOL
        /// <summary>
        /// Method is static
        /// Writing all data to the file
        /// </summary>
        /// <return></return>
        /// <param name="p">First Name</param>
        /// <param name="os"></param>
        /// <param name="comboBox">Date Of Birth</param>
        /// <param name="status">Status</param>
        /// <param name="obj">Local Variable</param>
        public static bool Write(string p, Patient os, string comboBox, string status)
        {
            if (comboBox == status)
            {
                using (StreamWriter obj = new StreamWriter(p, true)) // without true, false is applied and the file is overwritten every time, and so appends new lines
                {
                    obj.Write(os.FName + " " + os.SName + " " + os.Data + " " + os.Status);
                    obj.WriteLine();
                }
            }
            return true;
        }

        #endregion
    }
}