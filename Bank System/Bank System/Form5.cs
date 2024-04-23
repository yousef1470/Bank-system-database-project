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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection("Data Source=yousef;Initial Catalog=BankSystem;Integrated Security=True");
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void GenerateReport_CheckedChanged(object sender, EventArgs e)
        {
            Con.Open();
            string Query = "SELECT Customer.Cname AS CustomerName, SUM(Loan.Amount) AS TotalLoanAmount FROM Customer JOIN Loan ON Customer.SSN = Loan.SSN  GROUP BY Customer.Cname";
            SqlDataAdapter sdl = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sdl);
            var dl = new DataSet();
            sdl.Fill(dl);
            List.DataSource = dl.Tables[0];
            Con.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
