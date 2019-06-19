namespace BankSystemHQC
{
    using System;
    using System.Collections.Generic;

    public class BankSystem
    {
        public static void Main()
        {
            DepositAccount rbbDepositAccount = new DepositAccount();
            LoanAccount rbbLoanAccount = new LoanAccount();
            MortgageAccount rbbMortgageAccount = new MortgageAccount();

            Individual firsIndividualCustomer = new Individual("Ivan Petrov", "3232344565");

            DepositAccount firstIndividualDeposit = new DepositAccount(firsIndividualCustomer, 1.5);
            MortgageAccount firstIndividualMortgage = new MortgageAccount(firsIndividualCustomer, 2.5, 2000);

            List<BankAccount> firstIndividualAccounts = new List<BankAccount>()
            {
                firstIndividualDeposit,
                firstIndividualMortgage
            };

            Bank raiffeisenBank = new Bank(firstIndividualAccounts, "RaiffeisenBank");

            firsIndividualCustomer.CustomerBankAccounts = firstIndividualAccounts;

            Console.WriteLine(firsIndividualCustomer.ToString());

            firstIndividualDeposit.MakeDeposit(2000);
            Console.WriteLine(firsIndividualCustomer.ToString());

            firstIndividualDeposit.MakeDeposit(10000);
            Console.WriteLine(firsIndividualCustomer.ToString());

            firstIndividualDeposit.Withdraw(3000);
            Console.WriteLine(firsIndividualCustomer.ToString());

            Company telerik = new Company("Telerik", "32460789");

            LoanAccount telerikLoan = new LoanAccount(telerik, 2.34, 5000);

            List<BankAccount> telerikAccounts = new List<BankAccount>()
            {
                telerikLoan
            };

            telerik.CustomerBankAccounts = telerikAccounts;
        }
    }
}
