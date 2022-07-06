//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using System.IO;

namespace Plik
{
    public class Check
    {
        /// <summary>
        /// Checks if file exists
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>True if file doesn't exist and create it otheri</returns>
        public static bool CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                return true;
            }
            return false;
        }
    }
}
