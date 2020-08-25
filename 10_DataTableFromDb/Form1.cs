using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _10_DataTableFromDb
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            // 1
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            DataTable table = new DataTable();

            FillTable(table, conn);
            dataGridView1.DataSource = table;
            if (conn != null)
                conn.Close();
        }

        private void FillTable(DataTable table, SqlConnection conn)
        {
            SqlCommand command = new SqlCommand("Select * from Student", conn);

            try
            {
                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        do
                        {
                            int line = 0;
                            while (reader.Read())
                            {
                                if (line == 0)
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {

                                        table.Columns.Add(reader.GetName(i));
                                    }
                                    line++;
                                }
                                DataRow r = table.NewRow();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    r[i] = reader[i];
                                }
                                table.Rows.Add(r);
                            }
                        } while (reader.NextResult());
                    }

                }

            }
            catch (SqlException e)
            { }
        }
    }
}
