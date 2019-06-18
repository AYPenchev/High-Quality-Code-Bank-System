namespace BankSystemHQC
{
    /// <summary>
    /// This class inherits from the base class BankAccount and implements interface IDeposit,
    /// and represents Mortgage Bank Account used by Customers in the Bank. 
    /// </summary>
    public class MortgageAccount : BankAccount, IDeposit
    {
        /// <summary>
        /// This constant string represents the name of the account.
        /// </summary>
        // This variable will be used in several places when the system is further developed.
        public const string MORTGAGE = "Mortgage";

        /// <summary>
        /// This constant field shows the months with half interest for customer.
        /// </summary>
        private const int MONTHS_WITH_HALF_INTEREST = 12;

        /// <summary>
        /// This field is used on many places and that is why it is declared as constant.
        /// </summary>
        private const double HALF_INTEREST = 0.5;

        /// <summary>
        /// Initializes a new instance of the <see cref="MortgageAccount"/> class with information inherited by the base class.
        /// </summary>
        public MortgageAccount() : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MortgageAccount"/> class with customer using this account,
        /// interest rate and due amount of money to be returned, inherited by the base class.
        /// </summary>
        public MortgageAccount(Customer customer, double interestRate, decimal dueAmount) : base(customer, interestRate)
        {
            this.DueAmount = dueAmount;
        }

        /// <summary>
        /// Gets the name of the Mortgage account.
        /// </summary>
        public override string Name => MORTGAGE;

        /// <summary>
        /// This function is overriden to get the interest amount specifically for this type account.
        /// </summary>
        /// <param name="numberOfMonths">When requesting what the interest amount should be, you should enter
        /// the number of months for which it should be calculated.</param>
        /// <returns>Returns the interests amount for the entered period in months.</returns>
        public override double GetInterestAmount(int numberOfMonths)
        {
            double interestAmount = 0;
            
            // When the month for interest amount are more than th number of month with half interest
            // then we calculate separately months with normal interest and months with half interest
            // and then combine them to receive the total interest amount.
            if (numberOfMonths >= MONTHS_WITH_HALF_INTEREST)
            {
                numberOfMonths -= MONTHS_WITH_HALF_INTEREST;
                interestAmount = interestAmount + (numberOfMonths * this.InterestRate);
            }

            interestAmount = interestAmount + (MONTHS_WITH_HALF_INTEREST * HALF_INTEREST * this.InterestRate);
            return interestAmount;
        }

        /// <summary>
        /// Implemented functionality from the interface IDeposit.
        /// </summary>
        /// <param name="depositAmount">The amount of money which will be deposited in Mortgage account.</param>
        public void MakeDeposit(decimal depositAmount)
        {
            this.CurrentAmount += depositAmount;
        }
    }
}
