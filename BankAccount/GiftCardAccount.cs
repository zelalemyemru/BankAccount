using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class GiftCardAccount:BankAccount
    {
        private decimal _monthlyDeposit = 0m;

        public GiftCardAccount(string name, decimal initialBalance) : base(name, initialBalance)  // we use ":base" syntax to indicate a call to a base class contructor.
        {

        }
        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)=> _monthlyDeposit = monthlyDeposit;
        public override void PerformMonthEndTransaction()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
        }
    }
}
