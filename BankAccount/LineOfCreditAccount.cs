using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class LineOfCreditAccount:BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance)  // we use ":base" syntax to indicate a call to a base class contructor.
        {

        }
        public override void PerformMonthEndTransaction()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                var interest = -Balance * 0.07m;
                MakeWithdraw(interest, DateTime.Now, "Charge monthly interest");
            }
        }
    }
}
