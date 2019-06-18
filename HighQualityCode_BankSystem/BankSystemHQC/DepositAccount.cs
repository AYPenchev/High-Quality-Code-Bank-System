namespace BankSystemHQC
{
    /// <summary>
    /// This class inherits from the base class BankAccount and implements two interfaces - IDeposit and IWithdraw,
    /// and represents Deposit Bank Account used by Customers in the Bank. 
    /// </summary>
    public class DepositAccount : BankAccount, IDeposit, IWithdraw
    {
        /// <summary>
        /// This constant string represents the name of the account.
        /// </summary>
        // This variable will be used in several places when the system is further developed.
        public const string DEPOSIT = "Deposit";

        /// <summary>
        /// Initializes a new instance of the <see cref="DepositAccount"/> class with information inherited by the base class.
        /// </summary>
        public DepositAccount() : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DepositAccount"/> class with customer using this account,
        /// interest rate and current amount of money of the bank account, inherited by the base class.
        /// </summary>
        public DepositAccount(Customer customer, double interestRate, decimal currentAmount = 0) : base(customer, interestRate, currentAmount)
        {

        }

        /// <summary>
        /// Gets the name of the Deposit account.
        /// </summary>
        public override string Name => DEPOSIT;

        /// <summary>
        /// This function is overriden to get the interest amount specifically for this type account.
        /// </summary>
        /// <param name="numberOfMonths">When requesting what the interest amount should be, you should enter
        /// the number of months for which it should be calculated.</param>
        /// <returns>Returns the interests amount for the entered period in months.</returns>
        public override double GetInterestAmount(int numberOfMonths)
        {
            if (this.Customer.GetBalance() > 0 && this.Customer.GetBalance() < 1000)
            {
                return 0;
            }

            double interestAmount = numberOfMonths * this.InterestRate;
            return interestAmount;
        }

        /// <summary>
        /// Implemented functionality from the interface IDeposit.
        /// </summary>
        /// <param name="depositAmount">The amount of money which will be deposited in Deposit account.</param>
        public void MakeDeposit(decimal depositAmount)
        {
            this.CurrentAmount += depositAmount;

            if (depositAmount > DEPOSIT_LIMIT_WITHOUT_TAX)
            {
                this.CurrentAmount = this.CurrentAmount - (depositAmount * DEPOSIT_PERCENT_TAX);
            }
        }

        /// <summary>
        /// Implemented functionality from the interface IWithdraw.
        /// </summary>
        /// <param name="withdrawAmount">The amount of money which will be withdrawn from Deposit account</param>
        public void Withdraw(decimal withdrawAmount)
        {
            this.CurrentAmount = this.CurrentAmount - (withdrawAmount + this.CalculatePercentageOf(withdrawAmount, WITHDRAW_PERCENT_TAX));
        }

        /// <summary>
        /// This method is helper to Withdraw method.
        /// </summary>
        /// <returns>Returns the money which will be taxed for the withdraw.</returns>
        private decimal CalculatePercentageOf(decimal amount, decimal percent)
        {
            return amount * percent / 100;
        }
    }
}
