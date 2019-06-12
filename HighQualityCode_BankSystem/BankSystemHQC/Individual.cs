namespace BankSystemHQC
{
    using System.Collections.Generic;

    public class Individual : Customer
    {
        public Individual() : base()
        {
            this.PersonalIDNumber = string.Empty;
        }

        public Individual(string name, string personalIDNumber, List<BankAccount> customerBankAccounts = null) :
                          base(name, customerBankAccounts)
        {
            this.PersonalIDNumber = personalIDNumber;
        }

        public string PersonalIDNumber { get; set; }

        public override string ToString()
        {
            string individualInformation = "Personal ID number: " + this.PersonalIDNumber + "\n" + base.ToString();
            return individualInformation;
        }
    }
}
