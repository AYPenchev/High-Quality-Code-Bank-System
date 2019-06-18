﻿namespace BankSystemHQC
{
    using System.Collections.Generic;

    /// <summary>
    /// This class inherits from the base class Customer, and represents Company using Bank Accounts. 
    /// </summary>
    public class Company : Customer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class with default parameters.
        /// </summary>
        public Company() : base()
        {
            this.CompanyRegistrationNumber = default(int);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class with name, registration number of the company and
        /// the Bank Accounts that the company use.
        /// </summary>
        public Company(string name, int companyRegistrationNumber, List<BankAccount> customerBankAccounts = null) :
                       base(name, customerBankAccounts)
        {
            this.CompanyRegistrationNumber = companyRegistrationNumber;
        }

        /// <summary>
        /// Gets or sets the company's registration number.
        /// </summary>
        public int CompanyRegistrationNumber { get; set; }

        /// <summary>
        /// It appends the registration number of the company to the base class ToString() functionality.
        /// </summary>
        /// <returns>Returns all the information about the company as customer.</returns>
        public override string ToString()
        {
            return "Company registration number: " + this.CompanyRegistrationNumber + "\n" + base.ToString();
        }
    }
}
