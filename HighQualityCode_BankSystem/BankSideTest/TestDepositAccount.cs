namespace BankSideTest
{
    using System;
    using BankSystemHQC;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDepositAccount
    {
        [TestMethod]
        public void MakeDepositToDepositAccount_CannotDepositNegativeAmount()
        {
            // Arrange
            Individual personToMakeDeposit = new Individual();
            DepositAccount deposit = new DepositAccount(personToMakeDeposit, 0.3);

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => deposit.MakeDeposit(-2));
        }

        [TestMethod]
        public void WithdrawFromDepositAccount_CannotWithdrawNegativeAmount()
        {
            // Arrange
            Individual personToWithdraw = new Individual();
            DepositAccount deposit = new DepositAccount(personToWithdraw, 0.3);

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => deposit.Withdraw(-2));
        }

        [TestMethod]
        public void GetInterestAmountForDepositAccount_MonthsCannotBeLessThanZero()
        {
            // Arrange
            Individual person = new Individual();
            DepositAccount deposit = new DepositAccount(person, 0.3);

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => deposit.GetInterestAmount(-2));
        }
    }
}
