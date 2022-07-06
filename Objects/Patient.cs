//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020

namespace Objects
{
    public class Patient
    {
        public Patient(string firstName, string secondName, string data, string patientStatus)
        {
            FirstName = firstName;
            SecondName = secondName;
            Data = data;
            PatientStatus = patientStatus;
        }
       
        public Patient()  { }

        public string FirstName { get; }
        public string SecondName { get; }
        public string Data { get; }
        public string PatientStatus { get; }
    }
}
