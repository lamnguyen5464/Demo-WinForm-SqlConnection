using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Repositories;
namespace WinFormsApp1
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CompanyDatabase db = CompanyDatabase.getIntance();
            db.doConnect();
            String sqlQuery = "SELECT * FROM Departments";

            DataSet dataSet = db.queryData(sqlQuery);

            labelTest.Text = dataSet.Tables.Count.ToString();

            if (dataSet.Tables.Count > 0)
            {
                comboAllData.DataSource = dataSet.Tables[0];
                comboAllData.DisplayMember = "Name";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyDatabase.getIntance().doDisconnect();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void labelTest_Click(object sender, EventArgs e)
        {

        }
    }
}
