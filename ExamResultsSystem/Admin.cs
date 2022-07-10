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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        examClassesDataContext context = new examClassesDataContext();
        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            adstid.Text = "";
            adname.Text = "";
            adsub1.Text = "";
            adsub2.Text = "";
            adsub3.Text = "";
            adstid.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var user = context.Results.Where(u => u.name.Equals(adname.Text)).FirstOrDefault();
                if (user == null && !string.IsNullOrEmpty(adname.Text))
                {

                    if (adname.Text.Equals(adname.Text) && !string.IsNullOrEmpty(adsub1.Text) && !string.IsNullOrEmpty(adsub2.Text) && !string.IsNullOrEmpty(adsub3.Text) && !string.IsNullOrEmpty(adstid.Text))
                    {
                        Result result = new Result();
                        result.studentID = Convert.ToInt32(adstid.Text);
                        result.name = adname.Text;
                        result.sub1 = adsub1.Text;
                        result.sub2 = adsub2.Text;
                        result.sub3 = adsub3.Text;
                        
                        context.Results.InsertOnSubmit(result);
                        context.SubmitChanges();
                        MessageBox.Show("Data added!", "Message", MessageBoxButtons.OK);
                        
                    }
                }
                else
                {
                    MessageBox.Show("failed!", "Message", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();
        }
    }
}
