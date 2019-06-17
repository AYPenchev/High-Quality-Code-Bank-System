namespace BankSystemHQC
{
    public class Loan : BankAccount, IDeposit
    {
        public const string LOAN = "Loan";
        private const int MONTHS_WITHOUT_INTEREST_INDIVIDUAL = 3;
        private const int MONTHS_WITHOUT_INTEREST_COMPANY = 2;

        public Loan() : base()
        {

        }

        public Loan(Customer customer, double interestRate, decimal dueAmount) : base(customer, interestRate)
        {
            this.DueAmount = dueAmount;
        }

        public override string Name => LOAN;

        public override double GetInterestAmount(int numberOfMonths)
        {
            if (this.Customer.GetType() == typeof(Individual).GetType())
            {
                if (numberOfMonths >= MONTHS_WITHOUT_INTEREST_INDIVIDUAL)
                {
                    numberOfMonths -= MONTHS_WITHOUT_INTEREST_INDIVIDUAL;
                }
            }
            else
            {
                if (numberOfMonths >= MONTHS_WITHOUT_INTEREST_COMPANY)
                {
                    numberOfMonths -= MONTHS_WITHOUT_INTEREST_COMPANY;
                }
            }

            double interestAmount = numberOfMonths * this.InterestRate;
            return interestAmount;
        }

        public void MakeDeposit(decimal depositAmount)
        {
            this.CurrentAmount += depositAmount;
        }
    }
}
