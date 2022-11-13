using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;

namespace finalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string conStr = "Data Source=ALICK;Initial Catalog=employeeSys;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM users WHERE name='"+txtName.Text+"'AND password = '"+txtPass.Text+"'", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                EmployeeSys formSys = new EmployeeSys();
                formSys.Show();
                this.Hide();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }
    }
}