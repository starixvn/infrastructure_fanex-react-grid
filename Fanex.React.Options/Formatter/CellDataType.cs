// -----------------------------------------------------------------------
// <copyright file="CellDataType.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.React.Options.Formatter
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Cell Data Type.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Reviewed.")]
    public enum CellDataType
    {
        /// <summary>
        /// Cell Data Type: Text.
        /// </summary>
        Text = 0,

        /// <summary>
        /// Cell Data Type: Integer.
        /// </summary>
        Integer = 1,

        /// <summary>
        /// Cell Data Type: Integer.
        /// </summary>
        IntegerRedPositive = 10,

        /// <summary>
        /// Cell Data Type: Integer.
        /// </summary>
        IntegerRedNegative = 11,

        /// <summary>
        /// Cell Data Type: Decimal.
        /// </summary>
        Decimal = 2,

        /// <summary>
        /// Cell Data Type: Decimal.
        /// </summary>
        DecimalRedPositive = 20,

        /// <summary>
        /// Cell Data Type: Decimal.
        /// </summary>
        DecimalRedNegative = 21,

        /// <summary>
        /// Cell Data Type: Decimal.
        /// </summary>
        DecimalRedAbsNegative = 22,

        /// <summary>
        /// Cell Data Type: Decimal.
        /// </summary>
        DecimalRedParenthesesNegative = 23,

        /// <summary>
        /// Cell Data Type: Percentage.
        /// </summary>
        Percentage = 3,

        /// <summary>
        /// Cell Data Type: Percentage.
        /// </summary>
        PercentageRedPositive = 30,

        /// <summary>
        /// Cell Data Type: Percentage.
        /// </summary>
        PercentageRedNegative = 31,

        /// <summary>
        /// Cell Data Type: Percentage.
        /// </summary>
        PercentageRedAbsNegative = 32,

        /// <summary>
        /// Cell Data Type: Percentage.
        /// </summary>
        PercentageRedParenthesesNegative = 33,

        /// <summary>
        /// Cell Data Type: Date Time.
        /// </summary>
        DateTime = 4,

        /// <summary>
        /// Cell Data Type: Date Time. Ex: 01/01/2015.
        /// </summary>
        DateTimeMMddyyyy = 40,

        /// <summary>
        /// Cell Data Type: Date Time. Ex: Dec 1, 2015.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Reviewed.")]
        DateTimeMMMdyyyy = 41,

        /// <summary>
        /// Cell Data Type: Date Time. Ex: 1/1/2015.
        /// </summary>
        DateTimedMyyyy = 42,

        /// <summary>
        /// Cell Data Type: Date Time. Ex: January 01, 2015.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Reviewed.")]
        DateTimeMmmmddyyyy = 43,

        /// <summary>
        /// Link type.
        /// </summary>
        Link = 5,
    }
}