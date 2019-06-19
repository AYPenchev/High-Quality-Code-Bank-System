namespace BankSystemHQC
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Abstract class used to represent different kinds of customers using different kinds of Bank Accounts.
    /// </summary>
    public abstract class Customer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with default parameters.
        /// </summary>
        protected Customer()
        {
            this.Name = string.Empty;
            this.CustomerBankAccounts = new List<BankAccount>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with name and List of Bank Accounts that
        /// the customer will use.
        /// </summary>
        protected Customer(string name, List<BankAccount> customerBankAccounts = null)
        {
            this.Name = name ?? throw new ArgumentNullException("Invalid name");
            this.CustomerBankAccounts = customerBankAccounts;
        }

        /// <summary>
        /// Gets or sets the Bank Accounts of the customer.
        /// </summary>
        public List<BankAccount> CustomerBankAccounts { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        protected string Name { get; set; }

        /// <summary>
        /// This methods combine all the money in different accounts for specific customer.
        /// </summary>
        /// <returns>Returns the balance, meaning the balance = currentAmount - dueAmount.</returns>
        public decimal GetBalance()
        {
            decimal allAccountsBalance = default(decimal);

            if (this.CustomerBankAccounts == null)
            {
                throw new NullReferenceException("No bank accounts found. You must implement customer's bank accounts!");
            }

            foreach (BankAccount account in this.CustomerBankAccounts)
            {
                allAccountsBalance = allAccountsBalance + account.CurrentAmount - account.DueAmount;
            }

            return allAccountsBalance;
        }

        /// <summary>
        /// Base functionality of the ToString() method used in all derived classes.
        /// </summary>
        /// <returns>Returns the information which is the same for all derived classes.</returns>
        public override string ToString()
        {
            string typesOfBankAccounts = this.GetAccountsType(this.CustomerBankAccounts);

            return "Name: " + this.Name + "\nBalance: " + this.GetBalance() + "\nCustomer Bank Accounts: " + typesOfBankAccounts;
        }

        /// <summary>
        /// Summarize the types of the accounts that the specific customer use.
        /// </summary>
        /// <param name="accountsList">List of all Bank Accounts that the specific customer use.</param>
        /// <returns>Returns all types of the accounts concatenated</returns>
        private string GetAccountsType(List<BankAccount> accountsList)
        {
            string typesOfBankAccounts = string.Empty;

            if (accountsList == null)
            {
                throw new NullReferenceException("No bank accounts found. You must implement customer's bank accounts!");
            }

            foreach (BankAccount type in accountsList)
            {
                typesOfBankAccounts = typesOfBankAccounts + type.Name + " ";
            }

            return typesOfBankAccounts;
        }
    }
}
