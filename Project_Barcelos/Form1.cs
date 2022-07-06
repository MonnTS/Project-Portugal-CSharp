//  Daniel Zujev & Aliaksandr Yurchyk
//  Programming Language II, Barcelous 29-05-2020

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Objects;
using Plik;
using RemoveFromFile;
using Rules;
using Writer;

namespace Project_Barcelos
{
    public partial class Form1 : Form
    {
        private readonly string _allPatientsFile = $"{Environment.CurrentDirectory}/allpatients.txt";
        private readonly string _criticalStatusFile = $"{Environment.CurrentDirectory}/critical.txt";
        private readonly string _heavyStatusFile = $"{Environment.CurrentDirectory}/heavy.txt";
        private readonly string _normalStatusFile = $"{Environment.CurrentDirectory}/normal.txt";

        public Form1()
        {
            InitializeComponent();

            Check.CreateFile(_allPatientsFile);
            Check.CreateFile(_normalStatusFile);
            Check.CreateFile(_heavyStatusFile);
            Check.CreateFile(_criticalStatusFile);
        }

        private void ReadFile(string line)
        {
            listView1.Items.Clear();
            var lines = File.ReadAllLines(line);
            string[] splitter = { " " };

            foreach (var str in lines)
            {
                var cells = str.Split(splitter, StringSplitOptions.None);
                var lvItem = new ListViewItem(cells[0], 0);
                Array.Clear(cells, 0, 1);
                lvItem.SubItems.AddRange(cells);
                listView1.Items.Add(lvItem);
            }
        }

        private void ReadFileStatus(string comboBox, string status, string f)
        {
            listView1.Items.Clear();
            if (comboBox == status)
            {
                var lines = File.ReadAllLines(f);
                string[] splitter = { " " };
                foreach (var str in lines)
                {
                    var cells = str.Split(splitter, StringSplitOptions.None);
                    var lvItem = new ListViewItem(cells[0], 0);
                    Array.Clear(cells, 0, 1);
                    lvItem.SubItems.AddRange(cells);
                    listView1.Items.Add(lvItem);
                }
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            var patient = new Patient(textBox1.Text, textBox2.Text, maskedTextBox1.Text, comboBox1.Text);
            if ((textBox1.Text == string.Empty) & (textBox2.Text == string.Empty) & (maskedTextBox1.Text.Length != 10) &
                (comboBox1.Text == string.Empty))
            {
                MessageBox.Show("Please, fill all cells", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ManagePatient.InsertPatient(patient);

            WriteInStatus.Write(_normalStatusFile, patient, comboBox1.Text, "Normal");
            WriteInStatus.Write(_heavyStatusFile, patient, comboBox1.Text, "Heavy");
            WriteInStatus.Write(_criticalStatusFile, patient, comboBox1.Text, "Critical");

            MessageBox.Show("Patient has been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var item = new ListViewItem(textBox1.Text);
            item.SubItems.Add(textBox2.Text);
            item.SubItems.Add(maskedTextBox1.Text);
            item.SubItems.Add(comboBox1.Text);
            listView1.Items.Add(item);

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            maskedTextBox1.Text = string.Empty;
        }

        private void bShowAll_Click(object sender, EventArgs e)
        {
            ReadFile("allpatients.txt");
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            RemovePatient.TryRemovePatient((int)numericUpDown1.Value);
        }

        private void ShowN_Click(object sender, EventArgs e)
        {
            ReadFileStatus(comboBox2.Text, "Normal", "normal.txt");
            ReadFileStatus(comboBox2.Text, "Heavy", "heavy.txt");
            ReadFileStatus(comboBox2.Text, "Critical", "critical.txt");
        }

        private void Rmv_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0) listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            using (var sw = new StreamWriter("allpatients.txt"))
            {
                var builder = new StringBuilder();
                foreach (ListViewItem item in listView1.Items)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        builder.Append(subItem.Text).Append(" ");
                    }
                    sw.WriteLine(builder.ToString());
                    builder.Clear();
                }
            }
        }
    }
}