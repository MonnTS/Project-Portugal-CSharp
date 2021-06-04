//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Objects;
using Rules;
using Plik;
using Writer;
using RemoveFromFile;

namespace Project_Barcelos
{
    /// <summary>
    /// Main Class
    /// </summary>
    public partial class Form1 : Form
    {
        #region MAIN

        #region TEXT FILES
        /// <summary>
        /// Creating to the current directory txt files
        /// <param name="plik">All patients in one txt file</param>
        /// <param name="plik1">Patients with normal status</param>
        /// <param name="plik2">Patients with heavy status</param>
        /// <param name="plik3">Patients with critical status</param>
        /// </summary>
        string plik = Environment.CurrentDirectory + "/" + "allpatients.txt";
        string plik1 = Environment.CurrentDirectory + "/" + "normal.txt";
        string plik2 = Environment.CurrentDirectory + "/" + "heavy.txt";
        string plik3 = Environment.CurrentDirectory + "/" + "critical.txt";
        #endregion

        #region READFILE
        /// <summary>
        /// Reading file f and write to the ListView
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public bool ReadFile(string f)
        {
            listView1.Items.Clear();
            var lines = File.ReadAllLines(f); //    Writing to this variable for the whole file
            string[] splitter = new String[] { " " }; //    Input splitts the subitem
            string[] cells; //  Writing one line per time
            ListViewItem lvItem;
            foreach (var str in lines)  //  For each line
            {
                cells = str.Split(splitter, StringSplitOptions.None); // splitts the words in array cells
                lvItem = new ListViewItem(cells[0], 0); // First subitem is the first word
                Array.Clear(cells, 0, 1); //array, the first index of range, number of elements
                lvItem.SubItems.AddRange(cells); // Adding the subitem in range of array cells
                listView1.Items.Add(lvItem); // Adding full item to the VievList 
                
            }

            return true;
        }
        #endregion

        #region READFILESTATUS
        /// <summary>
        /// Function read file f and show patients with the choosen status.
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="status"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public bool ReadFileStatus(string comboBox, string status, string f)
        {
            listView1.Items.Clear();    //Clear the items in ViewList
            if (comboBox == status) //  Check the status
            {
                var lines = File.ReadAllLines(f);   // Veriable f reads all lines in file
                string[] splitter = new String[] { " " };   // spliiter
                string[] cells; //  array
                ListViewItem lvItem;    // VievList
                foreach (var str in lines)  //  For each single line 
                {
                    cells = str.Split(splitter, StringSplitOptions.None);   //  splitts the words in array
                    lvItem = new ListViewItem(cells[0], 0);    //  First subitem is the first word
                    Array.Clear(cells, 0, 1); //array, the first index of range, number of elements
                    lvItem.SubItems.AddRange(cells);    //  Adding the subitem in the range of array
                    listView1.Items.Add(lvItem);    // Adding full item to the ViewList
                }
            }

           return true;
        }
        #endregion

        #region CHECKTHEFILE
        /// <summary>
        /// Checks if the file was created, if it is not, he creates.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            Plik.Check.CreateFile(plik);    // AllPatients.txt
            Plik.Check.CreateFile(plik1);   // Normal.txt
            Plik.Check.CreateFile(plik2);   // Heavy.txt
            Plik.Check.CreateFile(plik3);   // Critical.txt
        }
        #endregion

        #region ADDPATIENT
        /// <summary>
        /// Adding patients to the list, if the cells are not fully completed, the program will push to fill all cells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAdd_Click(object sender, EventArgs e)
        {
            bool flaga = false;

            Patient osoba = new Patient(textBox1.Text, textBox2.Text, maskedTextBox1.Text, comboBox1.Text);
            //  Creates local veriable, in which we will write everything what we need.
            if (textBox1.Text != String.Empty & textBox2.Text != String.Empty & maskedTextBox1.Text.Length == 10 & comboBox1.Text != String.Empty) flaga = true;
            //  Checks if all the cells were filled, if not - the message box will appear
            if (flaga == false)
            {
                MessageBox.Show("Please, fill all cells");
            }
            if (flaga == true)
            //  After he checks requirements and everything is OK, he will write the information about the patient to the status text files
            {
                Rules.ManagePatient.InsertPatient(osoba);

                Writer.WriteInStatus.Write(plik1, osoba, comboBox1.Text, "Normal");
                Writer.WriteInStatus.Write(plik2, osoba, comboBox1.Text, "Heavy");
                Writer.WriteInStatus.Write(plik3, osoba, comboBox1.Text, "Critical");

                MessageBox.Show("Patient has been added!");

                ListViewItem item = new ListViewItem(textBox1.Text);
                item.SubItems.Add(textBox2.Text);
                item.SubItems.Add(maskedTextBox1.Text);
                item.SubItems.Add(comboBox1.Text);
                listView1.Items.Add(item);
                //  Read the element and write to the colums.
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                maskedTextBox1.Text = string.Empty;
                //  Clear textboxs
            }
        }
        #endregion

        #region READALLPATIENTS
        /// <summary>
        /// Read the file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bShowAll_Click(object sender, EventArgs e)
        {
            ReadFile("allpatients.txt");
        }
        #endregion

        #region DELETEPATIEN
        /// <summary>
        /// Deleting the Patient by the number of the patient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDelete_Click(object sender, EventArgs e)
        {
            RemoveFromFile.RemovePatient.RemoveP((int)numericUpDown1.Value);
        }
        #endregion

        #region SHOWPATIENT
        /// <summary>
        /// Read from comboBox the name of status, and then read file with this status and show patients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowN_Click(object sender, EventArgs e)
        {
            ReadFileStatus(comboBox2.Text, "Normal", "normal.txt");
            ReadFileStatus(comboBox2.Text, "Heavy", "heavy.txt");
            ReadFileStatus(comboBox2.Text, "Critical", "critical.txt");
        }
        #endregion

        #region REMOVE
        /// <summary>
        /// If in file contain more files than 0, you can delete selected patient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rmv_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }
        #endregion

        #region SAVE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("allpatients.txt"))
            {
                StringBuilder builder = new StringBuilder();    //dynamic line
                foreach (ListViewItem item in listView1.Items) // For each item in Listview
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems) //For each subitem,
                    {
                        builder.Append(subItem.Text).Append(" "); // Append - function to add in class StrimBuilding
                    }
                    sw.WriteLine(builder.ToString());
                    builder.Clear();
                }
            }
        }
        #endregion

        #endregion
    }
}