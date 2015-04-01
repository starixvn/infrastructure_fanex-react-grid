// -----------------------------------------------------------------------
// <copyright file="GridOptions.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.React.Options.Core
{
    using System.Collections.Generic;
    using Fanex.React.Options.Formatter;

    /// <summary>
    /// React JS Options.
    /// </summary>
    public class GridOptions
    {
        public GridOptions()
        {
            ShowTitle = false;
            NoDataText = "No data.";
            MaxContentHeight = 500;
            MaxContentWidth = 1200;
            HeaderStyle = Formatter.HeaderStyle.HeaderOneLine;
            PagingOptions = new PagingOptions();
        }

        public bool ShowTitle { get; set; }

        public string TitleText { get; set; }

        public string NoDataText { get; set; }

        public bool ShowFooter { get; set; }

        public bool OddEvenRow { get; set; }

        public bool IsHighlightHover { get; set; }

        public bool IsPaging { get; set; }

        public bool IsServerPaging { get; set; }

        public PagingOptions PagingOptions { get; set; }

        public int MaxContentHeight { get; set; }

        public int MaxContentWidth { get; set; }

        public int GridWidth
        {
            get
            {
                var gridWidth = 0;
                var scrollWidth = 20;
                gridWidth += scrollWidth;
                if (GroupHeaders != null)
                {
                    foreach (var groupHeader in GroupHeaders)
                    {
                        if (groupHeader.MergeRowNumber > 1)
                        {
                            gridWidth += groupHeader.Width;
                        }
                    }
                }

                if (HeaderColumns != null)
                {
                    foreach (var col in HeaderColumns)
                    {
                        gridWidth += col.Width;
                    }
                }

                return gridWidth;
            }
        }

        public List<int> ColumnWidthList
        {
            get
            {
                var list = new List<int>();
                if (GroupHeaders != null)
                {
                    for (int i = 0; i < GroupHeaders.Count; i++)
                    {
                        int startInHeader = 0;
                        if (GroupHeaders[i].MergeRowNumber > 1)
                        {
                            list.Add(GroupHeaders[i].Width);
                        }
                        else
                        {
                            int j;
                            for (j = startInHeader; j < HeaderColumns.Count; j++)
                            {
                                list.Add(HeaderColumns[j].Width);
                            }

                            startInHeader = j;
                        }
                    }
                }
                else
                {
                    foreach (var cell in HeaderColumns)
                    {
                        list.Add(cell.Width);
                    }
                }

                return list;
            }
        }

        public HeaderStyle HeaderStyle { get; set; }

        public List<HeaderColumns> GroupHeaders { get; set; }

        public List<HeaderColumns> HeaderColumns { get; set; }

        public List<Row> BodyRows { get; set; }

        public List<Row> FooterRows { get; set; }
    }
}