using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmMain_LoginForm_PartPachler
{
    public partial class FrmLogIn : Form
    {
        private string password = "pw123";
        public FrmLogIn()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pwInput = this.tbxPassword.Text;
            if(pwInput==this.password)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password!");
                this.tbxPassword.Clear();
                this.tbxPassword.Focus();
            }
        }
    }
}
