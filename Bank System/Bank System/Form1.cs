using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Bank_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            if (User.SelectedIndex == 0)
            {
                if (SSN.Text == "" || Cname.Text == "" || Phone.Text == "" || Address.Text == "" || Cbranch_no.Text == "")
                {
                    MessageBox.Show("Missing infomations");
                }
                else {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = "INSERT INTO Customer (SSN, Cname, phone, Customer_Address,Branch_no) VALUES (" + SSN.Text + ",'" + Cname.Text + "','" + Phone.Text + "','" + Address.Text + "','" + Cbranch_no.Text + "')";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("New customer sign up successfully.");
                }
            }
            else
            {
                if (SSN.Text == "" || Cname.Text == "" || Phone.Text == "" || Address.Text == "" || Cbranch_no.Text == "")
                {
                    MessageBox.Show("Missing infomations");
                }
                else
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = "INSERT INTO Employee (Employee_id, Ename,phone,Eaddress,Branch_no) VALUES (" + SSN.Text + ",'" + Cname.Text + "','" + Phone.Text + "','" + Address.Text + "'," + Cbranch_no.Text + ")";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("New employee sign up successfully.");
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {

            if (User.SelectedIndex == 0)
            {
                if (SSN.Text == "" || Cname.Text == "" || Phone.Text == "" || Address.Text == "" || Cbranch_no.Text == "")
                {
                    MessageBox.Show("Missing infomations");
                }
                else
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = "Update Customer SET Cname = '" + Cname.Text + "',Phone = '" + Phone.Text + "',Customer_Address = '" + Address.Text + "',Branch_no = '" + Cbranch_no.Text + "'where SSN = '" + SSN.Text + "'";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Customer updated successfully.");
                }
            }
            else
            {
                if (SSN.Text == "" || Cname.Text == "" || Phone.Text == "" || Address.Text == "" || Cbranch_no.Text == "")
                {
                    MessageBox.Show("Missing infomations");
                }
                else
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = "Update Employee SET EName = '" + Cname.Text + "',Phone = '" + Phone.Text + "',Eaddress = '" + Address.Text + "',Branch_no = " + Cbranch_no.Text + "where Employee_id = " + SSN.Text + "";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Employee updated successfully.");
                }

            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (User.SelectedIndex == 0)
            {
                if (SSN.Text == "")
                {
                    MessageBox.Show("Please enter SSN for Customer you want to delete");
                }
                else
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = "DELETE from Customer where SSN = " + SSN.Text + "";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Customer deleted successfully.");
                }

            }
            else
            {
                if (SSN.Text == "")
                {
                    MessageBox.Show("Please enter ID for employee you want to delete");
                }
                else
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = "DELETE from Employee where Branch_no = " + SSN.Text + "";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Employee deleted successfully.");
                }
            }
        }

        private void AddBank_Click(object sender, EventArgs e)
        {
            if (Code.Text == "" || Bname.Text == "" || Bank_Address.Text == "")
            {
                MessageBox.Show("Missing infomations");
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "INSERT INTO Bank (Code, Bname, Bank_Address) VALUES (" + Code.Text + ",'" + Bname.Text + "','" + Bank_Address.Text + "')";
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("New bank added successfully.");
            }
        }

        private void UpdateBank_Click(object sender, EventArgs e)
        {
            if (Code.Text == "" || Bname.Text == "" || Bank_Address.Text == "")
            {
                MessageBox.Show("Missing infomations");
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "UPDATE Bank SET Bname = '" + Bname.Text + "', Bank_Address = '" + Bank_Address.Text + "' WHERE code = " + Code.Text + "";
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Bank updated successfully.");
            }
        }

        private void DeleteBank_Click(object sender, EventArgs e)
        {
            if (Code.Text == "")
            {
                MessageBox.Show("Please enter Code for Bank you want to delete");
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "DELETE from Bank where Code = " + Code.Text + "";
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Bank deleted successfully.");

            }
        }

        private void AddBranch_Click(object sender, EventArgs e)
        {
            if (Branch_no.Text == "" || Branch_Address.Text == "" || Branch_no.Text == "")
            {
                MessageBox.Show("Missing infomations");
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "INSERT INTO Branch (Branch_no, Branch_Address,Code) VALUES (" + Branch_no.Text + ",'" + Branch_Address.Text + "','" + Bcode.Text + "')";
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("New branch added successfully.");

            }
        }

        private void UpdateBranch_Click(object sender, EventArgs e)
        {
            if (Branch_no.Text == "" || Branch_Address.Text == "" || Branch_no.Text == "")
            {
                MessageBox.Show("Missing infomations");
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "UPDATE Branch SET Code = '" + Bcode.Text + "', Branch_Address = '" + Branch_Address.Text + "' WHERE Branch_no = " + Branch_no.Text + "";
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Branch updated successfully.");

            }
        }

        private void DeleteBranch_Click(object sender, EventArgs e)
        {
            if (Branch_no.Text == "")
            {
                MessageBox.Show("Please enter branch_no for Branch you want to delete");
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "DELETE from Branch where Branch_no = " + Branch_no.Text + "";
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Branch deleted successfully.");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankSystemDataSet.EMPLOYEE' table. You can move, or remove it, as needed.
            this.eMPLOYEETableAdapter.Fill(this.bankSystemDataSet.EMPLOYEE);
            // TODO: This line of code loads data into the 'bankSystemDataSet.CUSTOMER' table. You can move, or remove it, as needed.
            this.cUSTOMERTableAdapter.Fill(this.bankSystemDataSet.CUSTOMER);




        }

        private void ShowData_Click(object sender, EventArgs e)
        {
            this.cUSTOMERTableAdapter.Fill(this.bankSystemDataSet.CUSTOMER);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.eMPLOYEETableAdapter.Fill(this.bankSystemDataSet.EMPLOYEE);
        }

        private void GoToEmployee_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void GoToCustomer_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void GotoReport_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}
