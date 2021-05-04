using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------------------------");
            var account = new BankAccount("Abebe", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with balance of {account.Balance}");
            account.MakeWithdraw(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);
            Console.WriteLine("--------------------------------------------------------------------");
            //try
            //{
            //    var invalidAccount = new BankAccount("invalid", -55);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance");
            //    Console.WriteLine(e.ToString());
            //}

            // Test for a negative balance.
            //try
            //{
            //    account.MakeWithdraw(750, DateTime.Now, "Attempt to overdraw");
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine("Exception caught trying to overdraw");
            //    Console.WriteLine(e.ToString());
            //}
            Console.WriteLine("--------------------------------------------------------------------");
            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdraw(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdraw(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransaction();
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());
            Console.WriteLine("--------------------------------------------------------------------");
            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdraw(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransaction();
            Console.WriteLine("--------------------------------------------------------------------");
            var lineOfCredit = new LineOfCreditAccount("line of credit", 0);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdraw(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdraw(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransaction();
            Console.WriteLine(account.GetAccountHistory());

        }
    }
}
