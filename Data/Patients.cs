//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace Data
{
    /// <summary>
    /// Class checking if the Patient is added
    /// </summary>
    public class Patients
    {
        #region LIST
        /// <summary>
        /// Creating the List, in which we adding the Patient
        /// </summary>
        /// <param name="listPatients"></param>
        static List<Patient> listPatients = new List<Patient>();
        #endregion

        #region BOOL
        /// <summary>
        /// Method is static
        /// Checking if the object "p" is written 
        /// </summary>
        /// <return></return>
        /// <param name="p"></param>
        public static bool AddPatient(Patient p)
        {

            if (listPatients.Contains(p) == true)
            {
                return false;
            }
            listPatients.Add(p);
            return true;

        }
        #endregion
    }
}
