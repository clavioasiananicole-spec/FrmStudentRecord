using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmStudentRecord
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentNo.Text) || !Regex.IsMatch(txtStudentNo.Text, @"^\d+$"))
            {
                MessageBox.Show("Error: Student No. cannot be blank and must contain numbers only.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentNo.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || !Regex.IsMatch(txtLastName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Error: Last Name is required and must contain letters only (no numbers or mixed characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || !Regex.IsMatch(txtFirstName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Error: First Name is required and must contain letters only (no numbers or mixed characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMId.Text) || !Regex.IsMatch(txtMId.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Error: Middle Initial is required and must contain letters only (no numbers or mixed characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMId.Focus();
                return;
            }

            if (cmbProgram.SelectedIndex == -1 || string.IsNullOrEmpty(cmbProgram.Text))

            {

                MessageBox.Show("Error: Please select your Program.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbProgram.Focus();

                return;

            }

            if (string.IsNullOrWhiteSpace(txtAge.Text) || !int.TryParse(txtAge.Text, out int ageVal) || ageVal <= 0)

            {

                MessageBox.Show("Error: Please enter a valid number for Age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAge.Focus();

                return;

            }

            if (cmbGender.SelectedIndex == -1 || string.IsNullOrEmpty(cmbGender.Text))

            {

                MessageBox.Show("Error: Please select your Gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbGender.Focus();

                return;

            }

            if (dtpBirthday.Value.Date > DateTime.Now.Date)

            {

                MessageBox.Show("Error: Birthday cannot be a future date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dtpBirthday.Focus();

                return;

            }

            if (string.IsNullOrWhiteSpace(txtContactNo.Text) || !long.TryParse(txtContactNo.Text, out _) || txtContactNo.Text.Length != 11)

            {

                MessageBox.Show("Error: Contact No. must contain exactly 11 numbers only.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtContactNo.Focus();

                return;

            }

            string studentNo = txtStudentNo.Text;

            string fullName = $"{txtLastName.Text}, {txtFirstName.Text}, {txtMId.Text}.";

            string program = cmbProgram.Text;

            string gender = cmbGender.Text;

            string age = txtAge.Text;

            string birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");

            string contactNo = txtContactNo.Text;

            string[] registrationDetails = {

               "Student No.:" + studentNo,

               "Full Name: " + fullName,

               "Program: " + program,

               "Gender: " + gender,

               "Age: " + age,

               "Birthday: " + birthday,

               "Contact No." + contactNo           };
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = studentNo + ".txt";
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName)))
            {
                foreach (string line in registrationDetails)
                {
                    outputFile.WriteLine(line);
                }
            }
            MessageBox.Show("Registration text file successfully generated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void txtAge_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
