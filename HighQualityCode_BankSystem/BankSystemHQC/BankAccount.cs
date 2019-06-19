namespace BankSystemHQC
{
    using System;

    /// <summary>
    /// This class implements the interface IGetInterestAmount because all Bank Accounts must have interest amount.
    /// </summary>
    public abstract class BankAccount : IGetInterestAmount
    {
        /// <summary>
        /// This constant field is the same to all Bank Accounts and says the you can deposit up to 5000 leva without any tax.
        /// </summary>
        protected const int DEPOSIT_LIMIT_WITHOUT_TAX = 5000;

        /// <summary>
        /// This constant field shows what the percentage of all deposited sum will be taxed for the service.
        /// </summary>
        protected const decimal DEPOSIT_PERCENT_TAX = 0.05m;

        /// <summary>
        /// This constant field shows what the percentage of all withdrawn sum will be taxed for the service.
        /// </summary>
        protected const decimal WITHDRAW_PERCENT_TAX = 2.4m;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class with default parameters.
        /// </summary>
        protected BankAccount()
        {
            this.Customer = null;
            this.CurrentAmount = default(decimal);
            this.DueAmount = default(decimal);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class with Customer using the Bank Account with defined
        /// interest rate and current amount of money in the account.
        /// </summary>
        /// <param name="currentAmount">This parameter has default value if such is not entered.</param>
        protected BankAccount(Customer customer, double interestRate, decimal currentAmount = 0)
        {
            this.Customer = customer ?? throw new ArgumentNullException("Invalid Customer!");
            if (interestRate < 0)
            {
                throw new ArgumentOutOfRangeException("Inavalid interest rate!");
            }

            this.InterestRate = interestRate;
            this.CurrentAmount = currentAmount;
        }

        /// <summary>
        /// Gets the name of the account.  Require to be overriden.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets or sets the amount of money in the account only through the explicit account.
        /// </summary>
        public decimal CurrentAmount { get; protected set; }

        /// <summary>
        /// Gets or sets the due amount of the account only through the specific account. Does not require to be overriden,
        /// because it is not used  in all accounts.
        /// </summary>
        public virtual decimal DueAmount { get; protected set; }

        /// <summary>
        /// Gets or sets the customer using the bank account
        /// </summary>
        protected Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets what the interest rate for the specific account.
        /// </summary>
        protected double InterestRate { get; set; }

        /// <summary>
        /// This is an abstract method used to calculate different interest amount in different bank accounts.
        /// </summary>
        /// <param name="numberOfMonths">When requesting what the interest amount should be, you should enter
        /// the number of months for which it should be calculated.</param>
        /// <returns>Returns the interests amount for the entered period in months.</returns>
        public abstract double GetInterestAmount(int numberOfMonths);
    }
}
