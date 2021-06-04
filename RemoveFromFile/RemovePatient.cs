//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using System;
using System.IO;

namespace RemoveFromFile
{
    /// <summary>
    /// Class reading the first txt file with patients, then adding to a new file
    /// </summary>
    public class RemovePatient
    {
        public static bool RemoveP (int num)
        {
            #region VARIABLES
            /// <summary>
            /// Removing data from one file and moves it to the other
            /// </summary>
            /// <return></return>
            /// <param name="num"></param>
            /// <param name="line">Line in txt file</param>
            /// <param name="linenr">Number of Line</param>
            /// <param name="lineToDelete">Line which we want to delete</param>
            /// <param name="reader">Reading the file, from what we want to take information</param>
            /// <param name="writer">Writing from the old file information to the new txt file</param>
            string line = null;
            int linenr = 0;
            int lineToDelete = num;
            #endregion

            #region METHOD
            using (StreamReader reader = new StreamReader("allpatients.txt"))
            {
                using (StreamWriter writer = new StreamWriter("newallpatients.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        linenr++;

                        if (linenr == lineToDelete)
                            continue;

                        writer.WriteLine(line);
                    } 

                }
            }
            File.Delete("allpatients.txt");
            File.Move("newallpatients.txt", "allpatients.txt");
            /* Deleting the original base of information
             * then it will rename new file 
             *  */
            return true;
            #endregion
        }

    }
}
