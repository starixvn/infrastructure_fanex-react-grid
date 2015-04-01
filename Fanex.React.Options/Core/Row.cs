// -----------------------------------------------------------------------
// <copyright file="Row.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.React.Options.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Row
    {
        public int RowIndex { get; set; }

        public string RowClass { get; set; }

        public List<Column> Columns { get; set; }
    }
}