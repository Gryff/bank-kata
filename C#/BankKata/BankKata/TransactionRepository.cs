using System.Collections.Generic;

namespace BankKata
{
    public class TransactionRepository
    {
        private readonly List<Transaction> _transactions =  new List<Transaction>();
        
        public void AddDeposit(Transaction deposit)
        {
            _transactions.Add(deposit);
        }

        public void AddWithdrawal(Transaction withdrawal)
        {
            _transactions.Add(withdrawal);
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }
}