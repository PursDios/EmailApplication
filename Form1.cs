using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_Application
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //if both the text fields aren't empty.
            if(txtEmail.Text != "" && txtPassword.Text != "")
            {
                //Initalise
                Controller.getInstance().Initalise(this, txtEmail.Text, txtPassword.Text);
            }
            else
                MessageBox.Show("One or more of the fields is empty!","Invalid Input!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
