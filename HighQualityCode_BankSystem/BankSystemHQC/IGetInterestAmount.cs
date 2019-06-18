namespace BankSystemHQC
{
    /// <summary>
    /// Classes that implement this interface can define the method inside to get the interest amount.
    /// </summary>
    public interface IGetInterestAmount
    {
        /// <summary>
        /// This method can be implemented by different classes in different ways to get the interest amount.
        /// </summary>
        /// <param name="numberOfMonths">When requesting what the interest amount should be, you should enter
        /// the number of months for which it should be calculated.</param>
        double GetInterestAmount(int numberOfMonths);
    }
}
