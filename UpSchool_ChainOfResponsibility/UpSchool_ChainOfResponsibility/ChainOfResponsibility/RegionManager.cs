using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_ChainOfResponsibility.DAL;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class RegionManager : Employee
    {
        public override void ProcessRequest(WithdrawViewModel p)
        {
            Context context = new Context();

            if (p.Amount <= 2500000)
            {
        
                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Bölge Müdür  - Hilal Sarı";
                bankProcess.Description = "Müşteriye talep ettiği tutarın ödemesi Bölge Müdürü  tarafından  gerçekleştirildi";
                bankProcess.Amount = p.Amount;
                bankProcess.CustomerName = p.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();

            }
            else 
            {  

                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Bölge Müdürü - Nazlı Siyah";
                bankProcess.Description = "Müşteriye talep ettiği tutarın ödemesi Gerçekleşmedi. Limitgünlük çekim tutarının üzerinde olduğu için. ";
                bankProcess.Amount = p.Amount;
                bankProcess.CustomerName = p.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
             
            }
        }
    }
}
