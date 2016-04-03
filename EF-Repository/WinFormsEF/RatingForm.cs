using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EF_Repository.Data;

namespace WinFormsEF
{
    public partial class RatingForm : Form
    {
        public RatingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new EfContext();
            var unitofWorks = new UnitOfWork(context);

            if (checkBox1.Checked)
            {
                var usersWithValidEmail = (from u in unitofWorks.PlayersRepo.GetPlayers()
                                           where u.IsValidEmail == true
                                           select new { u.PlayerId, u.Login, u.Email, u.Date }).ToArray();
                dataGridView1.DataSource = usersWithValidEmail;
            }
            if(checkBox2.Checked)
            {
                var transactions = (from p in unitofWorks.TransactionsRepo.GetTranscations()
                                   orderby p.Sum descending
                                   select new { p.TransactId, p.PlayerId, p.Sum, p.Date }).
                Take(3).ToArray();
                dataGridView1.DataSource = transactions;
            }
            if (checkBox3.Checked)
            {
                var longestPassword = (from p in context.Players
                                       orderby p.Password descending
                                       select new { p.PlayerId, p.Login }).
                ToArray();
                dataGridView1.DataSource = longestPassword;
            }
            context.Dispose();
            UncheckingCheckBox();
        }


        private void UncheckingCheckBox()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
