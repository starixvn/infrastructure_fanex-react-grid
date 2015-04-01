// -----------------------------------------------------------------------
// <copyright file="HeaderColumns.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.React.Options.Core
{
    using Fanex.React.Options.Formatter;

    /// <summary>
    /// Header Columns.
    /// </summary>
    public class HeaderColumns
    {
        public HeaderColumns()
        {
            MergeColumnNumber = 1;
            MergeRowNumber = 1;
        }

        public int Index { get; set; }

        public string Name { get; set; }

        public int Width { get; set; }

        public int MergeColumnNumber { get; set; }

        public int MergeRowNumber { get; set; }

        public string Text { get; set; }

        public TextAlign TextAlign { get; set; }

        public string TDClass { get; set; }
    }
}