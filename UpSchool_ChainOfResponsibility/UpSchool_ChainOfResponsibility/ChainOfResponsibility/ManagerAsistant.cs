using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_ChainOfResponsibility.DAL;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class ManagerAsistant : Employee //Müdür yardımcısı
    {
        public override void ProcessRequest(WithdrawViewModel p)
        {
            Context context = new Context();
            if (p.Amount <= 70000)
            {
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Şube Müdür Yardımcısı - Hilal Sarı";
                bankProcess.Description = "Müşteriye talep ettiği tutarın ödemesi Şube Müdür Yardımcısı tarafından  gerçekleştirildi";
                bankProcess.Amount = p.Amount;
                bankProcess.CustomerName = p.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();


            }
            else if (NextApprover != null)
            {
              
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Şube Müdür Yardımcısı - Hilal Sarı";
                bankProcess.Description = "Müşteriye talep ettiği tutarın ödemesi Gerçekleşmedi. Limit Yetim dışında olduğu için Yetkili Şube Müdürüne  yönlendirildi. ";
                bankProcess.Amount = p.Amount;
                bankProcess.CustomerName = p.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(p);

            }
        }
    }
}
