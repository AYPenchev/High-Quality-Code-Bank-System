using System;

namespace BankSystemHQC
{
    /// <summary>
    /// This class inherits from the base class BankAccount and implements interface IDeposit,
    /// and represents Loan Bank Account used by Customers in the Bank. 
    /// </summary>
    public class LoanAccount : BankAccount, IDeposit
    {
        /// <summary>
        /// This constant string represents the name of the account.
        /// </summary>
        // This variable will be used in several places when the system is further developed.
        public const string LOAN = "Loan";

        /// <summary>
        /// This constant field shows the months without interest for individual.
        /// </summary>
        private const int MONTHS_WITHOUT_INTEREST_INDIVIDUAL = 3;

        /// <summary>
        /// This constant field shows the months without interest for company.
        /// </summary>
        private const int MONTHS_WITHOUT_INTEREST_COMPANY = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoanAccount"/> class with information inherited by the base class.
        /// </summary>
        public LoanAccount() : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoanAccount"/> class with customer using this account,
        /// interest rate and due amount of money to be returned, inherited by the base class.
        /// </summary>
        public LoanAccount(Customer customer, double interestRate, decimal dueAmount) : base(customer, interestRate)
        {
            if (dueAmount < 0)
            {
                throw new ArgumentOutOfRangeException("Due amount can't be less than zero!");
            }

            this.DueAmount = dueAmount;
        }

        /// <summary>
        /// Gets the name of the Loan account.
        /// </summary>
        public override string Name => LOAN;

        /// <summary>
        /// This function is overriden to get the interest amount specifically for this type account.
        /// </summary>
        /// <param name="numberOfMonths">When requesting what the interest amount should be, you should enter
        /// the number of months for which it should be calculated.</param>
        /// <returns>Returns the interests amount for the entered period in months.</returns>
        public override double GetInterestAmount(int numberOfMonths)
        {
            if (numberOfMonths < 0)
            {
                throw new ArgumentOutOfRangeException("Number of months can't be negative!");
            }

            // These checks validate whether Individual or Company use the Loan Account
            // and accordingly remove number of months from total months which are without interest rate.
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
            if (interestAmount < 0)
            {
                throw new ArgumentOutOfRangeException("Inavalid interest amount!");
            }

            return interestAmount;
        }

        /// <summary>
        /// Implemented functionality from the interface IDeposit.
        /// </summary>
        /// <param name="depositAmount">The amount of money which will be deposited in Loan account.</param>
        public void MakeDeposit(decimal depositAmount)
        {
            if (depositAmount < 0)
            {
                throw new ArgumentOutOfRangeException("You can't deposit negative amount of money!");
            } 

            this.CurrentAmount += depositAmount;
        }
    }
}
