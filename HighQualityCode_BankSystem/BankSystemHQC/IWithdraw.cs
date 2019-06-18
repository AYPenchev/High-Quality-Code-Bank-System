namespace BankSystemHQC
{
    /// <summary>
    /// Classes that implement this interface can define the method inside to withdraw money.
    /// </summary>
    public interface IWithdraw
    {
        /// <summary>
        /// This method can be implemented by different classes in different ways to withdraw money.
        /// </summary>
        /// <param name="depositAmount">The amount of money that will be withdrawn.</param>
        void Withdraw(decimal withdrawAmount);
    }
}
