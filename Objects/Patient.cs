//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    /// <summary>
    /// Class creating constructor for Patient
    /// </summary>
    public class Patient
    {
        #region ATRIBUTES
        /// <summary>
        /// Atributes
        /// </summary>
        /// <param name="fname">First Name</param>
        /// <param name="sname">Last Name</param>
        /// <param name="data">Date Of Birth</param>
        /// <param name="status">Status</param>
        private string fname;
        private string sname;
        private string data;
        private string status;
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Construtor
        /// </summary>
        public Patient(string fname, string sname, string data, string status)
        {
            this.fname = fname;
            this.sname = sname;
            this.data = data;
            this.status = status;
        }
       
        public Patient()  { }
        /// <summary>
        /// Construtor
        /// </summary>
        #endregion

        #region PROPERTIES

        public string FName { get { return fname; } set { fname = value; } }
        public string SName { get { return sname; } set { sname = value; } }
        public string Data { get { return data; } set { data = value; } }
        public string Status { get { return status; } set { status = value; } }
        #endregion
    }
}
