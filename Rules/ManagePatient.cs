//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using System;
using Data;
using Objects;

namespace Rules
{
    /// <summary>
    /// Class adding the Patient to the list
    /// </summary>
    public class ManagePatient
    {
        #region BOOL
        /// <summary>
        /// Boolean
        /// Method is static
        /// </summary>
        /// <return></return>
        /// <param name="p"></param>
        public static bool InsertPatient(Patient p)
        {
            return Patients.AddPatient(p);
        }

        #endregion
    }
}
