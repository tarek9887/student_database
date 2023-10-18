using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void department_TextChanged(object sender, EventArgs e)
        {

        }
        //save
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Data Source=DESKTOP-RJLLT5B\\SQLEXPRESS03;Initial Catalog=employee;Integrated Security=True";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                var insertQuery = "insert into tarek values(@Studentname,@MatricID,@department)";

                SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Studentname", name.Text);
                sqlCommand.Parameters.AddWithValue("@MatricID", ID.Text);
                sqlCommand.Parameters.AddWithValue("@department", department.Text);

               sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

               MessageBox.Show("Data Inserted Succesfully!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somthing went wrong");
            }


}
//show
private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Data Source=DESKTOP-RJLLT5B\\SQLEXPRESS03;Initial Catalog=employee;Integrated Security=True";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string readCommand = "";

                if (ID.Text.ToString() == "")
                {
                    readCommand = "select * from tarek";
                }
                else
                {
                    readCommand = "select * from tarek where matricId=@matricId";
                }

                SqlCommand sqlCommand = new SqlCommand(readCommand, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@matricId", ID.Text);


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }


            }
        }
}
