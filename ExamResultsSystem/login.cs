using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamResultsSystem
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        examClassesDataContext context = new examClassesDataContext();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                txtpassword.PasswordChar = '\0';
                
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtusername.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new register().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var user = context.Users.Where(u => u.username.Equals(txtusername.Text) && u.password.Equals(txtpassword.Text)).FirstOrDefault();

                if (user != null)
                {
                    if (user.role.Equals("Admin"))
                    {
                        new Admin().Show();
                        this.Hide();
                    }
                    else if (user.role.Equals("Student"))
                    {
                        new Student().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalied User");
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password invalied!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
