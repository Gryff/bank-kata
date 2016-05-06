using System;
using System.Collections.Generic;
using BankKata;
using NSubstitute;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    class TransactionRepositoryShould
    {
        [Test]
        public void Add_a_deposit()
        {
            var transactionRepository = 
                new TransactionRepository();
            
            transactionRepository.AddDeposit(new Transaction(500, DateTime.Today));
            
            Assert.That(transactionRepository.GetTransactions().Contains(
                new Transaction(500, DateTime.Today)));
        }

        [Test]
        public void Add_a_withdrawal()
        {
            var transactionRepository =
                new TransactionRepository();

            transactionRepository.AddWithdrawal(new Transaction(-200, DateTime.Today));

            //Assert.That(transactionRepository.GetTransactions().Contains(
            //    new Transaction(-200, DateTime.Today)));


            Assert.AreEqual(
                transactionRepository.GetTransactions()[0],
                new Transaction(-200, DateTime.Today));
        }
    }

    
}
