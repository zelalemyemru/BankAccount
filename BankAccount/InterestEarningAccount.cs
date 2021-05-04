using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class InterestEarningAccount: BankAccount
    {
        public InterestEarningAccount(string name,decimal initialBalance):base(name, initialBalance)  // we use ":base" syntax to indicate a call to a base class contructor.
        {

        }
        public override void PerformMonthEndTransaction()
                             
        {
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }
    }
}
