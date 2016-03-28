﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEF
{
    public partial class ContainerForm : Form
    {
        public ContainerForm()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm(){ MdiParent = this };
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form item in MdiChildren)
            {
                item.Close();
            }
        }

        private void createPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerForm form = new PlayerForm() { MdiParent = this };
            form.Show();
        }
    }
}