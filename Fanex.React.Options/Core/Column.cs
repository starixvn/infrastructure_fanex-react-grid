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
    using Fanex.React.Options.Utility;

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

        public Column(int index, object value, CellDataType cellDataType, TextAlign textAlign = TextAlign.Right)
        {
            Index = index;
            Value = value;
            CellDataType = cellDataType;
            TextAlign = textAlign;
            MergeColumnNumber = 1;
            MergeRowNumber = 1;
        }

        public int Index { get; set; }

        public string Name { get; set; }

        public int Width { get; set; }

        public TextAlign TextAlign { get; set; }

        public string FormatString { get; set; }

        public string TDClass { get; set; }

        public CellDataType CellDataType { get; set; }

        public object Value { get; set; }

        public bool IsRowIndex { get; set; }

        public int MergeColumnNumber { get; set; }

        public int MergeRowNumber { get; set; }

        public bool IsHightLight { get; set; }

        public bool Invisible { get; set; }

        public string CellClass { get; set; }

        public LinkInformation LinkInformation { get; set; }

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
                        return Value == null ? string.Empty : ((int)Value).ToString("#,0");

                    case CellDataType.Decimal:
                    case CellDataType.DecimalRedNegative:
                    case CellDataType.DecimalRedPositive:
                        return Value == null ? string.Empty : ((decimal)Value).ToString("0,0.00");
                    case CellDataType.DecimalRedAbsNegative:
                        return Value == null ? string.Empty : Math.Abs((decimal)Value).ToString("0,0.00");
                    case CellDataType.DecimalRedParenthesesNegative:
                        return Value == null ? string.Empty : Math.Abs((decimal)Value).ToString("(0,0.00)");

                    case CellDataType.DateTime:
                        return Value == null || string.IsNullOrEmpty(FormatString) ? string.Empty : ((DateTime)Value).ToString(FormatString);
                    case CellDataType.DateTimeMdyyyy:
                        return Value == null ? string.Empty : ((DateTime)Value).ToString("M/d/yyyy");
                    case CellDataType.DateTimeMMddyyyy:
                        return Value == null ? string.Empty : ((DateTime)Value).ToString("MM/dd/yyyy");
                    case CellDataType.DateTimedMyyyy:
                        return Value == null ? string.Empty : ((DateTime)Value).ToString("d/M/yyyy");
                    case CellDataType.DateTimeMMMdyyyy:
                        return Value == null ? string.Empty : ((DateTime)Value).ToString("MMM d, yyyy");
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
                        return string.Empty;
                }
            }
        }
    }
}