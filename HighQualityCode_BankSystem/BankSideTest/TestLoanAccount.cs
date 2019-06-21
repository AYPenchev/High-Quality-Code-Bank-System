namespace BankSideTest
{
    using System;
    using BankSystemHQC;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    class TestLoanAccount
    {
        [TestMethod]
        public void MakeDepositToLoanAccount_CannotDepositNegativeAmount()
        {
            // Arrange
            Individual personToMakeDeposit = new Individual();
            LoanAccount loan = new LoanAccount(personToMakeDeposit, 0.3, 1000);

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => loan.MakeDeposit(-2));
        }

        [TestMethod]
        public void GetInterestAmountForLoanAccount_MonthsCannotBeLessThanZero()
        {
            // Arrange
            Individual person = new Individual();
            LoanAccount loan = new LoanAccount(person, 0.3, 1000);

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => loan.GetInterestAmount(-2));
        }
    }
}
