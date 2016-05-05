namespace BankKata
{
    public class Account
    {
        private readonly TransactionRepository _transactionRepository;

        public Account(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Deposit(int amount)
        {
            _transactionRepository.RegisterDeposit(amount);
        }

        public void Withdraw(int amount)
        {
            _transactionRepository.RegisterWithdrawal(amount);
        }
    }
}