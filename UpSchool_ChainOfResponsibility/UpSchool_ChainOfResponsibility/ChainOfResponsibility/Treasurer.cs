using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_ChainOfResponsibility.DAL;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee //veznedar
    {
        public override void ProcessRequest(WithdrawViewModel p)
        {
            Context context = new Context();
            if (p.Amount <= 40000)
            {
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Veznedar - Ayşenur Yıldız";
                bankProcess.Description = "Müşteriye talep ettiği tutarın ödemesi gerçekleştirildi";
                bankProcess.Amount = p.Amount;
                bankProcess.CustomerName = p.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();


            }
            else if (NextApprover != null)
            {
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Veznedar - Ayşenur Yıldız";
                bankProcess.Description = "Müşteriye talep ettiği tutarın ödemesi Gerçekleşmedi. Limit Yetim dışında olduğu için Yetkili Şube Müdür yardımcısına yönlendirildi. ";
                bankProcess.Amount = p.Amount;
                bankProcess.CustomerName = p.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(p);
                


            }
        }
    }
}
