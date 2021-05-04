using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            } 
        }

        private static int accountNumberSeed = 1234567890;


        public virtual void PerformMonthEndTransaction()// when you create a method with a keyword "Virual" mean any derived class may choose to reimplement. Derived class will use a keyword "overrride" to define a new implementation.
                                                        //You can also declare abstract methods where derived classes must override the behavior. The base class does not provide an implementation for an abstract method.
        {

        }
        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
        private List<Transaction> allTransactions = new List<Transaction>();
        public void MakeDeposit(decimal amount,DateTime date,string note)
        {
            if (amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposite must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdraw(decimal amount, DateTime date, string note)
        {
            if (amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if(Balance-amount < 0)
            {
                throw new InvalidOperationException("Not sufficient fund for this withdraw");

            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Note}");
            }

            return report.ToString();
        }
    }
}
