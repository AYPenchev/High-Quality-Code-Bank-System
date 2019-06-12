namespace BankSystemHQC
{
    using System.Collections.Generic;

    public class Company : Customer
    {
        public Company() : base()
        {
            this.CompanyRegistrationNumber = default(int);
        }

        public Company(string name, int companyRegistrationNumber, List<BankAccount> customerBankAccounts = null) :
                       base(name, customerBankAccounts)
        {
            this.CompanyRegistrationNumber = companyRegistrationNumber;
        }

        public int CompanyRegistrationNumber { get; set; }

        public override string ToString()
        {
            return "Company registration number: " + this.CompanyRegistrationNumber + "\n" + base.ToString();
        }
    }
}
