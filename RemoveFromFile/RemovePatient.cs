//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using System.IO;

namespace RemoveFromFile
{
    public class RemovePatient
    {
        private const string OldFileName = "allpatients.txt";
        private const string NewFileName = "newpatients.txt";
        
        /// <summary>
        /// Removes patient in text file
        /// </summary>
        /// <param name="num">Number of a line</param>
        /// <returns>True if deleted with success; False if number is less than 0</returns>
        public static bool TryRemovePatient (int num)
        {
            if (num < 0)
            {
                return false;
            }
            
            int linenr = 0;

            using (StreamReader reader = new StreamReader(OldFileName))
            {
                using (StreamWriter writer = new StreamWriter(NewFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        linenr++;

                        if (linenr == num)
                            continue;

                        writer.WriteLine(line);
                    }
                }
            }

            File.Delete(OldFileName);
            File.Move(NewFileName, OldFileName);
            return true;
        }
    }
}
