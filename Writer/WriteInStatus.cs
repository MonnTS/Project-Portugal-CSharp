//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using System.IO;
using Objects;

namespace Writer
{

    public class WriteInStatus
    {
        /// <summary>
        ///   Write in status file
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="patient">Object Patient</param>
        /// <param name="comboBox">Status from combobox</param>
        /// <param name="status">Patient status</param>
        /// <returns>True if status matched otherwise false</returns>
        public static bool Write(string path, Patient patient, string comboBox, string status)
        {
            if (comboBox == status)
            {
                using (StreamWriter obj = new StreamWriter(path, true))
                {
                    obj.Write($"{patient.FirstName} {patient.SecondName} {patient.Data} {patient.PatientStatus}");
                    obj.WriteLine();
                }
                return true;
            }
            return false;
        }
    }
}