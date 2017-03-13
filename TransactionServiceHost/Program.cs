using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using TransactionServiceLibrary;

namespace TransactionServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri tcpBaseAddress = new Uri("net.tcp://localhost:6789/");

            ServiceHost Sh = new ServiceHost(typeof(EmployeeSalary), new Uri[] { tcpBaseAddress });

            var netTcpBinding=new NetTcpBinding();

            netTcpBinding.TransactionFlow = true;

            ServiceEndpoint Se = Sh.AddServiceEndpoint(typeof(IEmployeeSalary),netTcpBinding , tcpBaseAddress);


            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            Sh.Description.Behaviors.Add(smb);

            ServiceEndpoint tcpSeMex = Sh.AddServiceEndpoint(typeof(IMetadataExchange),
                                                             MetadataExchangeBindings.CreateMexTcpBinding(),
                                                             "net.tcp://localhost:6789/mex");

            Sh.Open();

            Console.WriteLine("Started.....");

            foreach (var item in Sh.Description.Endpoints)
            {
                Console.WriteLine("Address: " + item.Address.ToString());
                Console.WriteLine("Binding: " + item.Binding.Name.ToString());
                Console.WriteLine("Contract: " + item.Contract.Name.ToString());
            }

            Console.ReadLine();

            Sh.Close();
        }
    }
}
