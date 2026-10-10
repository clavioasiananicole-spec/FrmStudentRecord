using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmStudentRecord
{
    public partial class frmFileName : Form
    {

        public static string SetFileName { get; set; }
        public frmFileName()
        {
            InitializeComponent();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFileName.Text))

            {

                MessageBox.Show("Error: File name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtFileName.Focus();

                return;

            }

            SetFileName = txtFileName.Text + ".txt";

            this.Close();

        }

    }

}