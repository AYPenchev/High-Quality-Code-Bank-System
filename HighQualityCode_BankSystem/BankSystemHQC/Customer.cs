
namespace BankSystemHQC
{
    using System.Collections.Generic;

    public abstract class Customer
    {
        protected Customer()
        {
            this.Name = string.Empty;
            this.CustomerBankAccounts = new List<BankAccount>();
        }

        protected Customer(string name, List<BankAccount> customerBankAccounts = null)
        {
            this.Name = name;
            this.CustomerBankAccounts = customerBankAccounts;
        }

        public List<BankAccount> CustomerBankAccounts { get; set; }
        protected string Name { get; set; }

        public decimal GetBalance()
        {
            decimal allAccountsBalance = default(decimal);

            foreach (BankAccount account in this.CustomerBankAccounts)
            {
                allAccountsBalance = allAccountsBalance + account.CurrentAmount - account.DueAmount;
            }

            return allAccountsBalance;
        }

        public override string ToString()
        {
            string typesOfBankAccounts = GetAccountsType(this.CustomerBankAccounts);

            return "Name: " + this.Name + "\nBalance: " + this.GetBalance() + "\nCustomer Bank Accounts: " + typesOfBankAccounts;
        }

        private string GetAccountsType(List<BankAccount> accountsList)
        {
            string typesOfBankAccounts = string.Empty;

            foreach (BankAccount type in accountsList)
            {
                typesOfBankAccounts = typesOfBankAccounts + type.Name + " ";
            }

            return typesOfBankAccounts;
        }
    }
}
