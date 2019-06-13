namespace BankSystemHQC
{
    using System.Collections.Generic;

    public class Bank
    {
        public Bank()
        {
            this.AccountTypes = new List<BankAccount>();
            this.Name = string.Empty;
        }

        public Bank(List<BankAccount> accountTypes, string name)
        {
            this.AccountTypes = accountTypes;
            this.Name = name;
        }

        public List<BankAccount> AccountTypes { get; set; }
        public string Name { get; set; }
    }
}
