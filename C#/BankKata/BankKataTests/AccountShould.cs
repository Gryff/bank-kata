using BankKata;
using NSubstitute;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    public class AccountShould
    {
        private TransactionRepository _transactionRepository;
        private Account _account;

        [SetUp]
        public void SetUp()
        {
            _transactionRepository = Substitute.For<TransactionRepository>();
            _account = new Account(_transactionRepository);
        }

        [Test]
        public void Make_a_deposit()
        {
            _account.Deposit(500);

            _transactionRepository.Received().RegisterDeposit(500);
        }

        [Test]
        public void Make_a_withdrawal()
        {
            _account.Withdraw(200);

            _transactionRepository.Received().RegisterWithdrawal(200);
        }
    }
}
