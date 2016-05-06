using System;
using BankKata;
using NSubstitute;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    public class PrintStatement
    {
        private readonly IConsole _console = Substitute.For<IConsole>();
        private readonly IClock _clock = Substitute.For<IClock>();

        [Test]
        public void Account_prints_correct_statement()
        {
            var account = new Account(
                new TransactionRepository(), _clock, _console);

            _clock.Now().Returns(new DateTime(2012, 01, 10));
            account.Deposit(1000);

            _clock.Now().Returns(new DateTime(2012, 01, 13));
            account.Deposit(2000);

            _clock.Now().Returns(new DateTime(2012, 01, 14));
            account.Withdraw(500);

            account.PrintStatement();

            Received.InOrder(() =>
            {
                _console.Received()
                    .PrintLine("date       || credit   || debit    || balance");
                _console.Received()
                    .PrintLine("14/01/2012 || || 500.00 || 2500.00");
                _console.Received()
                    .PrintLine("13/01/2012 || 2000.00 || || 3000.00");
                _console.Received()
                    .PrintLine("10/01/2012 || 1000.00 || || 1000.00");
            });
        }
    }
}
