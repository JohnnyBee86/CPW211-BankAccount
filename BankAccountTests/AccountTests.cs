using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize]
        public void CreateDefaultAccount()
        {
            acc = new Account("J Doe");
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.999)]
        [DataRow(9_999.99)]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange Act Assert
            
            // Arrange
            double depositAmount = 100;
            double expectedReturn = 100;

            // Act
            double returnValue = acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Arrange

            // Act => Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Deposit(invalidDepositAmount));
        }

        // Withdrawing a positive amount - returns updated balance
        // Withdrawing 0 - throws ArgumentOutRange
        // Withdrawing negative amount - throws ArgumentOutRange
        // Withdrawing more than balance - throws ArgumentException

        [TestMethod]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            double initialDeposit = 100;
            double withdrawAmount = 50;
            double expectedBalance = initialDeposit - withdrawAmount;

            acc.Deposit(initialDeposit);
            double actualBalance = acc.Withdraw(withdrawAmount);


            Assert.AreEqual(expectedBalance, actualBalance);
        }
    }
}