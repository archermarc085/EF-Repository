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

namespace WinFormsEF
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                var myCheckingValidateUser = CheckingValidateUser();
                if (myCheckingValidateUser != null)
                {
                    MessageBox.Show("Ok!", "Message");
                    this.Hide();
                    DataForm form = new DataForm() { MdiParent = this.MdiParent as ContainerForm };
                    form.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed!");
                }
            }
            if (radioButton2.Checked)
            {
                MessageBox.Show("Welcome Guest!");
                this.Hide();
                CombatsForm form = new CombatsForm() { MdiParent = this.MdiParent as ContainerForm };
                form.Show();
                this.Close();
            }
        }

        private Player CheckingValidateUser()
        {
            var context = new EfContext();
            var myCheckingValidateUser = (from p in context.Players
                where p.Login == textBox1.Text && p.Password == textBox2.Text
                select p).FirstOrDefault();
            context.Dispose();
            return myCheckingValidateUser;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                button1.PerformClick();
            }
        }

        private void radioGuestAuth_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Enabled = false;
            textBox2.Text = "";
            textBox2.Enabled = false;
            label1.Enabled = false;
            label2.Enabled = false;
        }
        private void radioUserAuth_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            label1.Enabled = true;
            label2.Enabled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
    }
}
