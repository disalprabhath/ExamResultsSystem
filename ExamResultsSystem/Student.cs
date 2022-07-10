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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }
        examClassesDataContext context = new examClassesDataContext();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<Result> data = context.Results.ToList();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Result> data = context.Results.Where(n => n.name.Equals(stname.Text)).ToList();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new main().Show();
            this.Hide();
        }
    }
}
