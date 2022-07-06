//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using System.Collections.Generic;
using Objects;

namespace Data
{
    public class Patients
    {
        private static List<Patient> _listPatients = new List<Patient>();

        /// <summary>
        /// Checks whether the patient is in the list of patients.
        /// </summary>
        /// <param name="patient">Object Patient</param>
        /// <returns>True if a patient is not on the list otherwise false</returns>
        public static bool AddPatient(Patient patient)
        {
            if (_listPatients.Contains(patient))
            {
                return false;
            }

            _listPatients.Add(patient);
            return true;
        }
    }
}
