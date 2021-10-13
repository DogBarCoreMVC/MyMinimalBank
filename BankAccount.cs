using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMinimalBank
{
    public class BankAccount
    {
        //Properties
        public string AcconutNumberID { get; }

        public string OwnerName { get; set; }

        public decimal BalanceAccount
        {
            get 
            {
                decimal balance = 0;

                foreach (var item in allTransactions)
                {
                    balance += item.Amonut;
                }
                return balance;
            }
        }

        private static long AccountID = 1234567890;//addsing value ใน class นี้เท่านั้น (private)

        private List<Transaction> allTransactions = new List<Transaction>();//create object allTransactions

        public BankAccount(string name, decimal initialBalance)//create constructor
        {//function เปิดบัญชีเงินฝากใหม่
           
            OwnerName = name;

            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");

            AcconutNumberID = AccountID.ToString();
            AccountID++;

            //แก้ไขได้ใน constructor เท่านั้น เพราะว่า properties Balance setไว้ให้ getter value ได้เพียงอย่างเดียว
            //ค่าของ AccountID จะบวกเพิ่ม เพื่อไม่ให้เลขบัญชีซ้ำเดิม
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)//method ฝากเงิน
        {
            if (amount <= 0)//ยอดเงินที่ต้องการฝากเงิน ซึ่งถ้าน้อยกว่า 0 exception จะแสดง
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amonut of deposit must be posivite");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)//method ถอนเงิน
        {
            if (amount <= 0)//ยอดเงินที่ต้องการถอน ซึ่งถ้าน้อยกว่า 0 exception จะแสดง
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amonut of withdrawal must be posivite");
            }
            if (BalanceAccount - amount < 0)//ยอดเงินที่มีอยู่ในบัญชี - ยอดเงินที่ต้องการถอน ซึ่งถ้าน้อยกว่า 0 exception จะแสดง
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrwal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAcconutHistoly()//Method แสดงรายละเอียด วันเวลา จำนวนเงิน บันทึก
        {
            var report = new StringBuilder();

            report.AppendLine("Date\t\tAmunt\tNote");

            foreach (var item in allTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amonut}\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}
