using System;
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
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
        }

        private void playersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fCDbDataSet);

        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fCDbDataSet.Transcations' table. You can move, or remove it, as needed.
            this.transcationsTableAdapter.Fill(this.fCDbDataSet.Transcations);
            // TODO: This line of code loads data into the 'fCDbDataSet.HitLogs' table. You can move, or remove it, as needed.
            this.hitLogsTableAdapter.Fill(this.fCDbDataSet.HitLogs);
            // TODO: This line of code loads data into the 'fCDbDataSet.Combats' table. You can move, or remove it, as needed.
            this.combatsTableAdapter.Fill(this.fCDbDataSet.Combats);
            // TODO: This line of code loads data into the 'fCDbDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.fCDbDataSet.Players);

        }
    }
}
