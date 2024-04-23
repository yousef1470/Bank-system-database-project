using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bank_System
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankSystemDataSet.LOAN' table. You can move, or remove it, as needed.
            this.lOANTableAdapter.Fill(this.bankSystemDataSet.LOAN);




        }

        private void RequestLoan_Click(object sender, EventArgs e)
        {
            if (SSN.Text == "" || Branch_no.Text == "" || Amount.Text == "" || Loan_Type.Text == "")
            {
                MessageBox.Show("Missing infomations");
                
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = "INSERT INTO Loan (SSN, Branch_no, Amount,Ltype) VALUES (" + SSN.Text + ", " + Branch_no.Text + " ," + Amount.Text + " , '"+ Loan_Type.Text+"')";
                sqlCommand.ExecuteNonQuery();
                this.lOANTableAdapter.Fill(this.bankSystemDataSet.LOAN);
                sqlConnection.Close();
                MessageBox.Show("New request send successfully.");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        
    }
}
