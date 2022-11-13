using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace finalProject
{
    public partial class EmployeeSys : Form
    {
        public EmployeeSys()
        {
            InitializeComponent();
        }


        SqlConnection conn;

        private void EmployeeSys_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblTime.Text = now.ToString("F");

            
            string conStr = "Data Source=ALICK;Initial Catalog=employeeSys;Integrated Security=True";
            conn = new SqlConnection(conStr);
        }

        private void clearFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtSalary.Clear();
            txtTax.Clear();
            txtAge.Clear();
            cmbGender.ResetText();

        }
        private void loadData()
        {
            conn.Open();
            string query = "SELECT * FROM employees";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtSalary.Text == "" || txtTax.Text == "" || txtAge.Text == "" || cmbGender.Text == "")
            {
                MessageBox.Show("Cannot Save empty fields");
            }
            else
            {
                conn.Open();
                string query;
                query = "INSERT INTO employees(id, name, gender, age, salary, tax) VALUES('" + txtId.Text + "','" + txtName.Text + "','" + cmbGender.Text + "','" + txtAge.Text + "','" + txtSalary.Text + "','" + txtTax.Text + "')";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();
                clearFields();
                loadData(); 
                MessageBox.Show("Employee Added Successfully...");
            }
        }

        

        private void btnView_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtSalary.Text == "" || txtTax.Text == "" || txtAge.Text == "" || cmbGender.Text == "")
            {
                MessageBox.Show("Cannot Update empty fields");
            }
            else
            {

                conn.Open();
                string query = "UPDATE employees SET id ='" + txtId.Text + "',name = '" + txtName.Text + "',Gender = '" + cmbGender.Text + "', salary = '" + txtSalary.Text + "',age = '" + txtAge.Text + "',tax = '" + txtTax.Text + "' where id ='" + txtId.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();
                loadData();
                clearFields();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Enter ID to Delete");
            }
            else
            {
                conn.Open();
                string query = "delete from employees where id='" + txtId.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();
                loadData();

            }
        }
    }
}
