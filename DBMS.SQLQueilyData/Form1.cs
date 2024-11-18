using Microsoft.Data.SqlClient;
using System.Data;
namespace DBMS.SQLQueilyData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        private void connect()
        {
            //เชื่อมต่อ database
            string servar = @"DESKTOP-BR15INT\sqlexpress";
            string db = "Minimart";
            string strCon = string.Format(@"Data Source={0};Initial Catalog={1};" + "Integrated Security=True;Encrypt=False", servar, db);
            conn = new SqlConnection(strCon);
            conn.Open();
        }

        private void disconnect()
        {
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
            showData("select * from Products");//นำข้อมูลมา show

        }

        private void showData(string sql)
        {
            //ข้อมูลจากฐานข้อมูล
            //string sql = "select * from Products";
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ปุ่มกดดึงข้อมูลจากฐานข้อมูล
            showData("select EmployeeID,Title+FirstName+' '+LastName EmpName,Position from Employees");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ปุ่มกดดึงข้อมูลจากฐานข้อมูล
            showData("select * from Categories");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ปุ่มกดดึงข้อมูลจากฐานข้อมูล
            showData("select * from Products");
        }
    }
}
