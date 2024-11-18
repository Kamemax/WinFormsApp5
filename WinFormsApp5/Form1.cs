using Microsoft.Data.SqlClient;
using System.Data;
namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connect();
            showData("select e.EmployeeID,Title,e.FirstName+''+e.LastName Empname,e.Position from Employees e");
        }
        SqlConnection conn; // Fixed typo from sqlConnection to SqlConnection.
        SqlCommand cmd;     // Fixed typo from sqlcommcand to SqlCommand.
        SqlDataAdapter da;  // Fixed typo from sqlDataAdapter to SqlDataAdapter.
        private void Connect()
        {
            string server = @".\sqlexpress";
            string db = "Minimart";
            string strCon = string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True ;Encrypt = false", server, db); // Fixed syntax errors.
            conn = new SqlConnection(strCon);
            conn.Open();
        }
        private void Disconnect()
        {
            conn.Close();

        }



        private void showData(string sql)
        {
            //string sql = "select * from Products";
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showData("select e.EmployeeID,Title,e.FirstName+''+e.LastName Empname,e.Position from Employees e");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showData("select * from Categories");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showData("select * from Products");
        }

        
    }
}

