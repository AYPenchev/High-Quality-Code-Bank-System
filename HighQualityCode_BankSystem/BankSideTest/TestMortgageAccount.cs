namespace BankSideTest
{
    using System;
    using BankSystemHQC;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestMortgageAccount
    {
        [TestMethod]
        public void MakeDepositToMortgageAccount_CannotDepositNegativeAmount()
        {
            // Arrange
            Individual personToMakeDeposit = new Individual();
            MortgageAccount mortgage = new MortgageAccount(personToMakeDeposit, 0.3, 1000);

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => mortgage.MakeDeposit(-2));
        }

        [TestMethod]
        public void GetInterestAmountForMortgageAccount_MonthsCannotBeLessThanZero()
        {
            // Arrange
            Individual person = new Individual();
            MortgageAccount mortgage = new MortgageAccount(person, 0.3, 1000);

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => mortgage.GetInterestAmount(-2));
        }
    }
}
