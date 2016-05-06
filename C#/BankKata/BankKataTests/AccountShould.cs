using System;
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
            IClock clock = Substitute.For<IClock>();
            clock.Now().Returns(DateTime.Today);
            _transactionRepository = Substitute.For<TransactionRepository>();
            _account = new Account(
                _transactionRepository, clock, new StatementPrinter());
        }

        [Test]
        public void Make_a_deposit()
        {
            _account.Deposit(500);

            _transactionRepository.Received().AddDeposit(
                new Transaction(500, DateTime.Today));
        }

        [Test]
        public void Make_a_withdrawal()
        {
            _account.Withdraw(200);

            _transactionRepository.Received().AddWithdrawal(
                new Transaction(-200, DateTime.Today));
        }
    }
}
