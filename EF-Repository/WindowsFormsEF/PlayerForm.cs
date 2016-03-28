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
using EF_Repository.Model;

namespace WindowsFormsEF
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();
        }

        private static int count = 4;
       
        private void PlayerForm_Load(object sender, EventArgs e)
        {
          

        }

        private bool check = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                check = true;
            }
            var player = new Player() { Login = textBox1.Text, Password = textBox2.Text, Email = textBox3.Text, IsValidEmail = check , CombatId = count};
            var context = new EfContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.PlayersRepo.Add(player);
            context.SaveChanges();
            context.Dispose();
            MessageBox.Show("Ok!");
            count++;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
