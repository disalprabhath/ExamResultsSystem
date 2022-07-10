using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ExamResultsSystem
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        examClassesDataContext context = new examClassesDataContext();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void regemail_Validating(object sender, CancelEventArgs e)
        {
            if (Regex.IsMatch(regemail.Text, @"^([\w\.\-]+)@([\w\-]+)(\.(\w){2,3})+$"))
            {
                errorProvider1.SetError(regemail, "");
            }

            else
            {
                errorProvider1.SetError(regemail, "Invalid Email Address ");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (regpassword.Text == regconpassword.Text)
            {
                try
                {
                    var user = context.Users.Where(u => u.username.Equals(regusername.Text)).FirstOrDefault();
                    if (user == null && !string.IsNullOrEmpty(regusername.Text))
                    {

                        if (regpassword.Text.Equals(regconpassword.Text) && !string.IsNullOrEmpty(regpassword.Text) && !string.IsNullOrEmpty(comboBox.Text))
                        {
                            User newlogin = new User();
                            newlogin.username = regusername.Text;
                            newlogin.name = regname.Text;
                            newlogin.password = regpassword.Text;
                            newlogin.role = comboBox.Text;
                            newlogin.email = regemail.Text;

                            context.Users.InsertOnSubmit(newlogin);
                            context.SubmitChanges();
                            MessageBox.Show("Data added!", "Message", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Registration is failed!", "Message", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Password dosent match");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                List<User> data = context.Users.ToList();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();
        }
    }
}
