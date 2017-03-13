using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;
namespace TransactionServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeSalary
    {
        [OperationContract] 
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        int CreateEmployee(Employee E);


        [OperationContract] 
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void CreateSalaryHistory(SalaryHistory SH);
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Eid { get; set; }

        [DataMember]
        public string EName { get; set; }

        [DataMember]
        public double ESalary { get; set; }
    }

    [DataContract]
    public class SalaryHistory
    {
        [DataMember]
        public int SNo { get; set; }

        [DataMember]
        public int Eid { get; set; }

        [DataMember]
        public double ESalary { get; set; }

        [DataMember]
        public DateTime StDate { get; set; }

        [DataMember]
        public DateTime? EdDate { get; set; }

    }
}
    	
    
