//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using Data;
using Objects;

namespace Rules
{
    public class ManagePatient
    {
        /// <summary>
        /// Using method from class Data to add new patient to the list of patients.
        /// </summary>
        /// <param name="patient">Object Patient</param>
        /// <returns>True if added a patient with success otherwise false</returns>
        public static bool InsertPatient(Patient patient)
        {
            return Patients.AddPatient(patient);
        }
    }
}
