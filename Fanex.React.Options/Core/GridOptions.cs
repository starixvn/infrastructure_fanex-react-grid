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
            MaxContentWidth = 1000;
            ScrollAreaFixedWidth = 500;
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

        public bool IsRenderLargeData { get; set; }

        public string RenderLargeDataCallBack { get; set; }

        public int NumberOfFreezeColumn { get; set; }

        public int GridWidth { get; set; }

        public int FreezeAreaWidth { get; set; }

        public int ScrollAreaWidth { get; set; }

        public int ScrollAreaFixedWidth { get; set; }

        public List<int> ColumnWidthList { get; set; }

        public HeaderStyle HeaderStyle { get; set; }

        public List<HeaderColumns> GroupHeaders { get; set; }

        public List<HeaderColumns> HeaderColumns { get; set; }

        public List<Row> BodyRows { get; set; }

        public List<Row> FooterRows { get; set; }
    }
}