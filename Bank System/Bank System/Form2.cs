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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            PersonalLoan();
            CommercialLoan();
            IndustryLoan();
        }
        SqlConnection Con = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");

        
       private void PersonalLoan()
        {
            
            Con.Open();
            string Query = "select LTYPE,LOAN_NO,SSN,AMOUNT,BRANCH_NO from loan where LTYPE = 'personal'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LoanDetail.DataSource = ds.Tables[0];
            Con.Close();
            
        }
        private void CommercialLoan()
        {
            Con.Open();
            string Query = "select LTYPE,LOAN_NO,SSN,AMOUNT,BRANCH_NO from loan where LTYPE = 'commercial'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LoanDetail.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void IndustryLoan()
        {
            Con.Open();
            string Query = "select LTYPE,LOAN_NO,SSN,AMOUNT,BRANCH_NO from loan where LTYPE = 'industry'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LoanDetail.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankSystemDataSet.LOAN' table. You can move, or remove it, as needed.
            this.lOANTableAdapter.Fill(this.bankSystemDataSet.LOAN);



        }



        private void User_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(User.SelectedIndex == 0)
            {
                PersonalLoan();
            }
            else if(User.SelectedIndex == 1)
            {
                CommercialLoan();
            }
            else if(User.SelectedIndex == 2)
            {
                IndustryLoan();
            }
            else
            {
                Con.Open();
                string Query = "select * from loan";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                LoanDetail.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Con.Open();
            string Query = "SELECT l.loan_no, l.Ltype, l.amount, c.CNAME AS customer_name, e.ENAME AS employee_name " +
                "FROM Loan l JOIN Customer c ON l.branch_no = c.branch_no " +
                "JOIN Employee e ON l.branch_no = e.branch_no where l.SSN = c.SSN";
            SqlDataAdapter sdl = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sdl);
            var dl = new DataSet();
            sdl.Fill(dl);
            Listofloans.DataSource = dl.Tables[0];
            Con.Close();
        }
      

    private void Exit_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

    }
}
