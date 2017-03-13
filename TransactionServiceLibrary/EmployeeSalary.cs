using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;

namespace TransactionServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
        
    [ServiceBehavior(TransactionIsolationLevel=IsolationLevel.Serializable,TransactionTimeout="00:00:30")]
    public class EmployeeSalary : IEmployeeSalary
    {

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public int CreateEmployee(Employee E)
        {
            int Eid = 0;
            var con = new SqlConnection("Data Source=MTHAPA\\MTHAPA;Initial Catalog=TransactionDb;Integrated Security=True");
            var cmd = new SqlCommand("insert into Employee (EName,ESalary) values (@EName,@ESalary); select SCOPE_IDENTITY()", con);
            cmd.Parameters.AddWithValue("@EName", E.EName);
            cmd.Parameters.AddWithValue("@ESalary", E.ESalary);
            con.Open();
            SqlDataReader EmployeeReader = cmd.ExecuteReader();
            if (EmployeeReader.Read())
            {
                Eid = int.Parse(EmployeeReader[0].ToString());
            }
            EmployeeReader.Close();
            con.Close();
            return Eid;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void CreateSalaryHistory(SalaryHistory SH)
        {
            var con = new SqlConnection("Data Source=MTHAPA\\MTHAPA;Initial Catalog=TransactionDb;Integrated Security=True");
            var cmd = new SqlCommand("insert into SalaryHistory (Eid,ESalary,StDate,EdDate) values (@Eid,@ESalary,@StDate,NULL)", con);
            cmd.Parameters.AddWithValue("@Eid", SH.Eid);
            cmd.Parameters.AddWithValue("@ESalary", SH.ESalary);
            cmd.Parameters.AddWithValue("@StDate", SH.StDate);
			con.Open();
            cmd.ExecuteNonQuery();            
            con.Close();
        }
    }
}
