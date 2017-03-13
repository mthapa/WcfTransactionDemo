using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransactionServiceClient.TransactionServiceReference;
using System.Transactions;
using System.Data.SqlClient;

namespace TransactionServiceClient
{
	public partial class EmployeeMgmt : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!Page.IsPostBack)
			{
				txtEmployeeName.Text = "";
				txtEmployeeSalary.Text = "";
				txtStatus.Text = "";
			}

		}

		protected void btnCreate_Click(object sender, EventArgs e)
		{
			try
			{
				var TS = new EmployeeSalaryClient();
				using (TransactionScope Trs = new TransactionScope())
				{
					int id = TS.CreateEmployee(new Employee() { EName = txtEmployeeName.Text, ESalary = double.Parse(txtEmployeeSalary.Text) });
					if (id != 0)
					{
						TS.CreateSalaryHistory(new SalaryHistory() { Eid = id, ESalary = double.Parse(txtEmployeeSalary.Text), StDate = DateTime.Now, EdDate = null });
					}

					//Log to the client side
					CreateTransactionLog(new Transaction { TDate = DateTime.Now, TInfo = String.Format("Name:{0},Salary:{1} ", txtEmployeeName.Text, txtEmployeeSalary.Text) });

					Trs.Complete();
				}

				txtStatus.Text = String.Format("Success.");

			}
			catch (Exception ex)
			{

				txtStatus.Text = String.Format("Error {0}", ex.Message);
			}

		}


		public void CreateTransactionLog(Transaction tlog)
		{
			var con = new SqlConnection("Data Source=MTHAPA\\MTHAPA;Initial Catalog=TransactionDb;Integrated Security=True");
			var cmd = new SqlCommand("insert into Transactions1 (TInfo, TDate) values (@TInfo, @TDate)", con);
			cmd.Parameters.AddWithValue("@TInfo", tlog.TInfo);
			cmd.Parameters.AddWithValue("@TDate", tlog.TDate);
			con.Open();
			cmd.ExecuteNonQuery();
			con.Close();
		}



	}

	public class Transaction
	{
		public int Tid { get; set; }
		public String TInfo { get; set; }
		public DateTime TDate { get; set; }

	}
}