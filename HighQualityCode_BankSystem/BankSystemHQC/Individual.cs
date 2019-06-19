namespace BankSystemHQC
{
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// This class inherits from the base class Customer, and represents Individual using Bank Accounts. 
    /// </summary>
    public class Individual : Customer
    {
        private const int PERSONAL_ID_LENGTH = 10;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Individual"/> class with default parameters.
        /// </summary>
        public Individual() : base()
        {
            this.PersonalIDNumber = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Individual"/> class with name, personal ID number of the person and
        /// the Bank Accounts that the individual use.
        /// </summary>
        public Individual(string name, string personalIDNumber, List<BankAccount> customerBankAccounts = null) :
                          base(name, customerBankAccounts)
        {
            if (personalIDNumber.Length != PERSONAL_ID_LENGTH)
            {
                throw new FormatException("Registration number in Bulgaria has length of 8 symbols!");
            }
            this.PersonalIDNumber = personalIDNumber;
        }

        /// <summary>
        /// Gets or sets the personal ID number of the individual.
        /// </summary>
        public string PersonalIDNumber { get; set; }

        /// <summary>
        /// It appends the personal ID number of the individual to the base class ToString() functionality.
        /// </summary>
        /// <returns>Returns all the information about the individual as customer.</returns>
        public override string ToString()
        {
            string individualInformation = "Personal ID number: " + this.PersonalIDNumber + "\n" + base.ToString();
            return individualInformation;
        }
    }
}
