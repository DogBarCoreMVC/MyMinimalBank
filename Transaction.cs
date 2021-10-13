using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMinimalBank
{
    class Transaction
    {
        public decimal Amonut { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string notes)
        {
            Amonut = amount;
            Date = date;
            Notes = notes;
        }
    }
}
