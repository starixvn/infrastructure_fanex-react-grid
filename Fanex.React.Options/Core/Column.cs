// -----------------------------------------------------------------------
// <copyright file="Column.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.React.Options.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Fanex.React.Options.Formatter;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Column
    {
        public Column()
        {
            TextAlign = Formatter.TextAlign.Right;
            CellDataType = Formatter.CellDataType.Decimal;
            MergeColumnNumber = 1;
            MergeRowNumber = 1;
        }

        public int Index { get; set; }

        public string Name { get; set; }

        public int Width { get; set; }

        public TextAlign TextAlign { get; set; }

        public string TDClass { get; set; }

        public CellDataType CellDataType { get; set; }

        public object Value { get; set; }

        public int MergeColumnNumber { get; set; }

        public int MergeRowNumber { get; set; }

        public bool IsHightLight { get; set; }

        public bool Invisible { get; set; }

        public string TextAlignment
        {
            get
            {
                switch (TextAlign)
                {
                    case TextAlign.Left:
                        return "left";
                    case TextAlign.Right:
                        return "right";
                    case TextAlign.Center:
                        return "center";
                    default:
                        return string.Empty;
                }
            }
        }

        public string CellClass
        {
            get
            {
                switch (CellDataType)
                {
                    case CellDataType.IntegerRedPositive:
                    case CellDataType.DecimalRedPositive:
                    case CellDataType.PercentageRedPositive:
                        return (decimal)Value > 0 ? "red" : string.Empty;
                    case CellDataType.IntegerRedNegative:
                    case CellDataType.DecimalRedNegative:
                    case CellDataType.DecimalRedAbsNegative:
                    case CellDataType.DecimalRedParenthesesNegative:
                    case CellDataType.PercentageRedNegative:
                    case CellDataType.PercentageRedAbsNegative:
                    case CellDataType.PercentageRedParenthesesNegative:
                        return (decimal)Value < 0 ? "red" : string.Empty;
                    default:
                        return string.Empty;
                }
            }
        }

        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Reviewed.")]
        public string DisplayText
        {
            get
            {
                switch (CellDataType)
                {
                    case CellDataType.Text:
                        return Value.ToString();

                    case CellDataType.Integer:
                    case CellDataType.IntegerRedNegative:
                    case CellDataType.IntegerRedPositive:
                        return Value == null ? string.Empty : ((int)Value).ToString("0,0");

                    case CellDataType.Decimal:
                    case CellDataType.DecimalRedNegative:
                    case CellDataType.DecimalRedPositive:
                        return Value == null ? string.Empty : ((decimal)Value).ToString("0,0.00");
                    case CellDataType.DecimalRedAbsNegative:
                        return Value == null ? string.Empty : Math.Abs((decimal)Value).ToString("0,0.00");
                    case CellDataType.DecimalRedParenthesesNegative:
                        return Value == null ? string.Empty : Math.Abs((decimal)Value).ToString("(0,0.00)");

                    case CellDataType.DateTime:
                    case CellDataType.DateTimeMMddyyyy:
                        return Value == null ? string.Empty : ((DateTime)Value).ToString("MM/dd/yyyy");
                    case CellDataType.DateTimeMdyyyy:
                        return Value == null ? string.Empty : ((DateTime)Value).ToString("M/d/yyyy");
                    case CellDataType.DateTimeMMMdyyyy:
                        return Value == null ? string.Empty : ((DateTime)Value).ToString("MMM dd, yyyy");
                    case CellDataType.DateTimeMmmmddyyyy:
                        return Value == null ? string.Empty : ((DateTime)Value).ToString("MMMM dd, yyyy");

                    case CellDataType.Percentage:
                    case CellDataType.PercentageRedNegative:
                    case CellDataType.PercentageRedPositive:
                        return Value == null ? string.Empty : (100 * (decimal)Value).ToString("0,0.00%");
                    case CellDataType.PercentageRedAbsNegative:
                        return Value == null ? string.Empty : (100 * Math.Abs((decimal)Value)).ToString("0,0.00%");
                    case CellDataType.PercentageRedParenthesesNegative:
                        return Value == null ? string.Empty : (100 * Math.Abs((decimal)Value)).ToString("(0,0.00%)");
                    default:
                        return Value.ToString();
                }
            }
        }
    }
}