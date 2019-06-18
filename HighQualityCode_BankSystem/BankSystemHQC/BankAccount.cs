namespace BankSystemHQC
{
    public abstract class BankAccount : IGetInterestAmount
    {
        protected const int DEPOSIT_LIMIT_WITHOUT_TAX = 5000;
        protected const decimal DEPOSIT_PERCENT_TAX = 0.05m;
        protected const decimal WITHDRAW_PERCENT_TAX = 2.4m;

        protected BankAccount()
        {
            this.Customer = null;
            this.CurrentAmount = default(decimal);
            this.DueAmount = default(decimal);
        }

        protected BankAccount(Customer customer, double interestRate, decimal currentAmount = 0)
        {
            this.Customer = customer;
            this.InterestRate = interestRate;
            this.CurrentAmount = currentAmount;
        }

        public abstract string Name { get; }

        public decimal CurrentAmount { get; protected set; }

        public virtual decimal DueAmount { get; protected set; }

        protected Customer Customer { get; set; }

        protected double InterestRate { get; set; }

        public abstract double GetInterestAmount(int numberOfMonths);
    }
}
