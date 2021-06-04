//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using System;
using System.IO;

namespace Plik
{
    /// <summary>
    /// Class checking the file for existing
    /// </summary>
    public class Check
    {
        #region BOOL
        /// <summary>
        /// This methods checks if file exists, if it is not - he creates
        /// Method is static
        /// </summary>
        /// <param name="p">Parametr</param>
        /// <returns></returns>
        public static bool CreateFile(string p)
        {
            if (File.Exists(p) == false)
            {
                File.Create(p);
                return true;
            }
            return false;
        }
        #endregion
    }
}
