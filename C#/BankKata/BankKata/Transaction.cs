using System;

namespace BankKata
{
    public class Transaction
    {
        private readonly int _amount;
        private readonly DateTime _transactionDate;

        public Transaction(int amount, DateTime transactionDate)
        {
            this._amount = amount;
            this._transactionDate = transactionDate;
        }

        public int Amount => _amount;

        public string ToOutputFormat()
        {
            var creditAndDebitColumns = 
                _amount > 0 ? 
                    $"{_amount}.00 ||" :
                    $"|| {-_amount}.00";

            return $"{_transactionDate.ToShortDateString()} || {creditAndDebitColumns}";
        }

        public override bool Equals(object obj)
        {
            Transaction t = obj as Transaction;

            if ((object) t == null) return false;

            return _amount == t._amount
                   && _transactionDate == t._transactionDate;
        }

        public bool Equals(Transaction t)
        {
            return _amount == t._amount
                   && _transactionDate == t._transactionDate;
        }
    }
}