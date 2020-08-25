using System;
using System.Data;
using System.Windows.Forms;

namespace _09_DataTable
{
    public partial class Form1 : Form
    {
        DataSet set = null;
        public Form1()
        {
            InitializeComponent();
            set = new DataSet();
            //       FillDataSet(set);
            LoadXml(set);
            dataGridView1.DataSource = set.Tables["tblCar"];
            // for wpf
            // datagrid.DataContext = table;
        }

        private void LoadXml(DataSet set)
        {
            set.ReadXml("car.xml");
        }

        private void FillDataSet(DataSet set)
        {
            DataTable table = new DataTable("tblCar");
            DataColumn col = new DataColumn("ID")
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                Caption = "Car #id",
                DataType = typeof(int),
                Unique = true
            };

            DataColumn brend = new DataColumn("Mark", typeof(string)) { Caption = "Brend" };
            DataColumn model = new DataColumn("Model", typeof(string));
            DataColumn year = new DataColumn("Year", typeof(int));
            DataColumn price = new DataColumn("Price", typeof(double));

            table.Columns.AddRange(new[] { col, brend, model, year, price });

            DataRow row = table.NewRow();
            //row["ID"] = 1;
            row["Mark"] = "Audi";
            row["Model"] = "A8";
            row["Year"] = 2018;
            row["Price"] = 17000;

            table.Rows.Add(row);

            row = table.NewRow();
            row["Mark"] = "BMW";
            row["Model"] = "X6";
            row["Year"] = 2020;
            row["Price"] = 36000;

            table.Rows.Add(row);

            set.Tables.Add(table);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Search
            DataRow[] rows = set.Tables[0].Select($"ID = {Int32.Parse(textBox1.Text)}");
            if (rows.Length != 0)
            {
                rows[0].Delete();
                //        set.Tables[0].AcceptChanges();
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("Not found!");
            }
        }

        private void update_click(object sender, EventArgs e)
        {
            DataRow[] rows = set.Tables[0].Select($"ID = {Int32.Parse(textBox2.Text)}");
            rows[0]["Price"] = Convert.ToDouble(textBox3.Text);
            //   set.Tables[0].AcceptChanges();    // optional, important in other db
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            set.WriteXml("car.xml");
        }
    }
}
