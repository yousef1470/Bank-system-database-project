using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_System
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankSystemDataSet.LOAN' table. You can move, or remove it, as needed.
            this.lOANTableAdapter.Fill(this.bankSystemDataSet.LOAN);
            // TODO: This line of code loads data into the 'bankSystemDataSet.CUSTOMER' table. You can move, or remove it, as needed.
            this.cUSTOMERTableAdapter.Fill(this.bankSystemDataSet.CUSTOMER);



        }

        private void AddCustomer_Click(object sender, EventArgs e)
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
                sqlCommand.CommandText = "INSERT INTO Customer (SSN, Cname, phone, Customer_Address,Branch_no) VALUES (" + SSN.Text + ",'" + Cname.Text + "','" + Phone.Text + "','" + Address.Text + "','" + Cbranch_no.Text + "')";
                sqlCommand.ExecuteNonQuery();
                this.cUSTOMERTableAdapter.Fill(this.bankSystemDataSet.CUSTOMER);
                sqlConnection.Close();
                MessageBox.Show("New customer sign up successfully.");
            }
        }

        

        private void AcceptedLoan_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "Update loan set status = 'accept' where loan_no = " + Loan_number.Text + "";
            sqlCommand.ExecuteNonQuery();
            this.lOANTableAdapter.Fill(this.bankSystemDataSet.LOAN);
            sqlConnection.Close();
            MessageBox.Show("loan accepted.");
        }

        private void RejectedLoan_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "Update loan set status = 'reject' where loan_no = " + Loan_number.Text + "";
            sqlCommand.ExecuteNonQuery();
            this.lOANTableAdapter.Fill(this.bankSystemDataSet.LOAN);
            sqlConnection.Close();
            MessageBox.Show("loan rejected.");
        }
    }
}
