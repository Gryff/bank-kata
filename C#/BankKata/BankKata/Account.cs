using System.Collections.Generic;

namespace BankKata
{
    public class Account
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly IClock _clock;
        private readonly IConsole _console;
        private readonly string HEADER = "date       || credit   || debit    || balance";

        public Account(TransactionRepository transactionRepository, IClock clock, IConsole console)
        {
            _clock = clock;
            _transactionRepository = transactionRepository;
            _console = console;
        }

        public void Deposit(int amount)
        {
            var deposit = new Transaction(amount, _clock.Now());
            _transactionRepository.AddDeposit(deposit);
        }

        public void Withdraw(int amount)
        {
            var withdrawal = new Transaction(-amount, _clock.Now());
            _transactionRepository.AddWithdrawal(withdrawal);
        }

        public void PrintStatement()
        {
            _console.PrintLine(HEADER);
            this.PrintTransactions();
        }

        private void PrintTransactions()
        {
            List<Transaction> transactions = _transactionRepository.GetTransactions();

            var formattedTransactions =
                this.FormatTransactions(transactions);

            foreach (var formattedTransaction in formattedTransactions)
            {
                _console.PrintLine(formattedTransaction);
            }
        }

        private List<string> FormatTransactions(List<Transaction> transactions)
        {
            int balance = 0;
            List<string> formattedTransactions = new List<string>();

            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
                formattedTransactions.Add(
                    $"{transaction.ToOutputFormat()} || {balance}.00");
            }

            formattedTransactions.Reverse();

            return formattedTransactions;
        }
    }
}