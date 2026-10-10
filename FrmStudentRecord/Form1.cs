using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmStudentRecord
{
    public partial class FrmLab1 : Form
    {

        public FrmLab1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))

            {

                MessageBox.Show("Error: Input box cannot be empty. Please enter text before creating.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtInput.Focus();

                return;

            }


            frmFileName.SetFileName = "";

            frmFileName frm = new frmFileName();

            frm.ShowDialog();


            if (string.IsNullOrWhiteSpace(frmFileName.SetFileName))

            {

                MessageBox.Show("Operation cancelled: A valid file name is required to proceed.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;

            }


            string getInput = txtInput.Text;

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, frmFileName.SetFileName)))

            {

                outputFile.WriteLine(getInput);

                Console.WriteLine(getInput);

            }

            this.Hide();
            MessageBox.Show("Lab 1 text file successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmRegistration regForm = new FrmRegistration();

            regForm.ShowDialog();


        

        }
    }
}
