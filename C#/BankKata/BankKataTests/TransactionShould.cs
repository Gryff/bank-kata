using System;
using BankKata;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    class TransactionShould
    {
        [Test]
        public void Format_a_deposit_Transaction()
        {
            var transaction = new Transaction(500, new DateTime(2016, 01, 01));

            Assert.AreEqual(
                "01/01/2016 || 500.00 ||",
                transaction.ToOutputFormat());
        }

        [Test]
        public void Format_a_withdrawal_Transaction()
        {
            var transaction = new Transaction(-500, new DateTime(2016, 01, 01));

            Assert.AreEqual(
                "01/01/2016 || || 500.00",
                transaction.ToOutputFormat());
        }
    }
}
