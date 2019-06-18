namespace BankSystemHQC
{
    using System.Collections.Generic;

    /// <summary>
    /// This class holds information about different Bank Accounts of different people, and the name of the bank.
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bank"/> class with default parameters.
        /// </summary>
        public Bank()
        {
            this.AccountTypes = new List<BankAccount>();
            this.Name = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bank"/> class with List of Bank Accounts and the name of the bank.
        /// </summary>
        public Bank(List<BankAccount> accountTypes, string name)
        {
            this.AccountTypes = accountTypes;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets accounts in the bank. 
        /// </summary>
        public List<BankAccount> AccountTypes { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the bank
        /// </summary>
        public string Name { get; set; }
    }
}
