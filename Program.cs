using System;
using System.Collections.Generic;

namespace MyMinimalBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var Account = new BankAccount("porawit", 1000);//เปิดบัญชี
            Console.WriteLine($"AccountID {Account.AcconutNumberID} Owname Bank Account {Account.OwnerName} Initial Balance you {Account.BalanceAccount}");

            Console.WriteLine();

            Account.MakeWithdrawal(300, DateTime.Now, "Vittamin");//ถอนเงิน

            Account.MakeWithdrawal(550, DateTime.Now, "Shopee");//ถอนเงิน

            Account.MakeDeposit(1000, DateTime.Now, "deposit");//ฝากเงิน

            Console.WriteLine();

            Console.WriteLine(Account.GetAcconutHistoly());//แสดงรายละเอียดบัญชี

            Console.WriteLine($"Account Balance {Account.BalanceAccount}");//สรุปเงินเหลือ
        }

    }
}

