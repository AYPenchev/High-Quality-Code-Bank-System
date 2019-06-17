namespace BankSystemHQC
{
    public class Deposit : BankAccount, IDeposit, IWithdraw
    {
        public const string DEPOSIT = "Deposit";

        public Deposit() : base()
        {

        }

        public Deposit(Customer customer, double interestRate, decimal currentAmount = 0) : base(customer, interestRate, currentAmount)
        {

        }

        public override string Name => DEPOSIT;

        public override double GetInterestAmount(int numberOfMonths)
        {
            if (this.Customer.GetBalance() > 0 && this.Customer.GetBalance() < 1000)
            {
                return 0;
            }

            double interestAmount = numberOfMonths * this.InterestRate;
            return interestAmount;
        }

        public void MakeDeposit(decimal depositAmount)
        {
            this.CurrentAmount += depositAmount;

            if (depositAmount > DEPOSIT_LIMIT_WITHOUT_TAX)
            {
                this.CurrentAmount = this.CurrentAmount - (depositAmount * DEPOSIT_PERCENT_TAX);
            }
        }

        public void Withdraw(decimal withdrawAmount)
        {
            this.CurrentAmount = this.CurrentAmount - (withdrawAmount + this.CalculatePercentageOf(withdrawAmount, WITHDRAW_PERCENT_TAX));
        }

        private decimal CalculatePercentageOf(decimal amount, decimal percent)
        {
            return amount * percent / 100;
        }
    }
}
