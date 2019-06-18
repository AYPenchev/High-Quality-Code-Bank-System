namespace BankSystemHQC
{
    /// <summary>
    /// Classes that implement this interface can define the method inside to deposit money.
    /// </summary>
    public interface IDeposit
    {
        /// <summary>
        /// This method can be implemented by different classes in different ways to deposit money.
        /// </summary>
        /// <param name="depositAmount">The amount of money that will be deposit.</param>
        void MakeDeposit(decimal depositAmount);
    }
}
