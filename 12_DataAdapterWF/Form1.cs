using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_DataAdapterWF
{
    public partial class Form1 : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        SqlConnection connection = null;
        SqlDataAdapter adapter = null;
        SqlCommandBuilder builder = null;
        DataSet set = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(tbCommand.Text, connection);
            builder = new SqlCommandBuilder(adapter);

            set = new DataSet();
            adapter.Fill(set);
            dataGridView1.DataSource = set.Tables[0];

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            adapter.Update(set);
        }
    }
}
