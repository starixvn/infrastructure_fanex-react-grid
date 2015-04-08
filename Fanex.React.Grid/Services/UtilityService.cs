namespace Fanex.React.Grid.Services
{
    using System;
    using System.Collections.Generic;
    using Fanex.React.Options.Core;
    using Fanex.React.Options.Formatter;
    using Fanex.React.Options.Utility;

    /// <summary>
    /// Utility Service.
    /// </summary>
    public class UtilityService
    {
        /// <summary>
        /// GET REACT GRID OPTIONS.
        /// </summary>
        /// <param name="numOfRow">NUMBER OF ROW.</param>
        /// <returns>GRID OPTIONS.</returns>
        public GridOptions GetReactGridOptions(int numOfRow)
        {
            var bodyRows = GetBodyRows(numOfRow);
            var gridOptions = new GridOptions
            {
                ShowTitle = true,
                TitleText = "Grid demo",
                NoDataText = "No data",
                ShowFooter = true,
                MaxContentHeight = 250,
                OddEvenRow = true,
                IsHighlightHover = false,
                ColumnWidthList = new List<int>() { 60, 100, 300, 100, 150, 150, 150, 100 },
                IsPaging = false,
                IsServerPaging = false,
                NumberOfFreezeColumn = 0,
                GroupHeaders = GetGroupHeader(),
                HeaderColumns = GetHeader(),
                BodyRows = bodyRows,
                FooterRows = GetFooterRows(),
            };

            return gridOptions;
        }

        /// <summary>
        /// GET REACT GRID OPTIONS.
        /// </summary>
        /// <param name="numOfRow">NUMBER OF ROW.</param>
        /// <returns>GRID OPTIONS.</returns>
        public GridOptions GetReactWithLinkGridOptions(int numOfRow)
        {
            var bodyRows = GetBodyRowsWithLink(numOfRow);
            var gridOptions = new GridOptions
            {
                ShowTitle = true,
                TitleText = "Grid demo",
                NoDataText = "No data",
                ShowFooter = true,
                MaxContentHeight = 250,
                OddEvenRow = true,
                IsHighlightHover = false,
                ColumnWidthList = new List<int>() { 60, 100, 250, 100, 120, 120, 120, 100 },
                IsPaging = false,
                IsServerPaging = false,
                NumberOfFreezeColumn = 0,
                GroupHeaders = GetGroupHeader(),
                HeaderColumns = GetHeader(),
                BodyRows = bodyRows,
                FooterRows = GetFooterRows(),
            };

            return gridOptions;
        }

        /// <summary>
        /// GET GROUP HEADER.
        /// </summary>
        /// <returns>HEADER COLUMNS.</returns>
        private List<HeaderColumns> GetGroupHeader()
        {
            var headers = new List<HeaderColumns>();

            headers.Add(new HeaderColumns(0, "#", TextAlign.Center) { MergeRowNumber = 2 });
            headers.Add(new HeaderColumns(1, "Date", TextAlign.Center) { MergeRowNumber = 2 });
            headers.Add(new HeaderColumns(2, "Username", TextAlign.Center) { MergeRowNumber = 2 });
            headers.Add(new HeaderColumns(3, "Bet Count", TextAlign.Center) { MergeRowNumber = 2 });
            headers.Add(new HeaderColumns(4, "Turnover", TextAlign.Center) { MergeColumnNumber = 3 });
            headers.Add(new HeaderColumns(7, "Margin", TextAlign.Center) { MergeRowNumber = 2 });

            return headers;
        }

        private List<HeaderColumns> GetHeader()
        {
            var headers = new List<HeaderColumns>();
            headers.Add(new HeaderColumns(4, "Turnover", TextAlign.Center));
            headers.Add(new HeaderColumns(5, "Customer W/L", TextAlign.Center));
            headers.Add(new HeaderColumns(6, "Licensee W/L", TextAlign.Center));
            return headers;
        }

        /// <summary>
        /// GET BODY ROWS.
        /// </summary>
        /// <param name="numOfRow">NUMBER OF ROWS.</param>
        /// <returns>LIST OF ROW.</returns>
        private List<Row> GetBodyRows(int numOfRow)
        {
            var rows = new List<Row>();
            for (int i = 0; i < numOfRow; i++)
            {
                var columns = new List<Column>();
                columns.Add(new Column() { Index = 0, TextAlign = TextAlign.Center, CellDataType = CellDataType.Integer, Value = i + 1 });
                columns.Add(new Column() { Index = 1, TextAlign = TextAlign.Center, CellDataType = CellDataType.DateTimeMMMdyyyy, Value = RandomDate() });
                columns.Add(new Column() { Index = 2, TextAlign = TextAlign.Left, CellDataType = CellDataType.Text, Value = i.ToString() + RandomText() });
                columns.Add(new Column() { Index = 3, CellDataType = CellDataType.Integer, Value = RandomInt() });
                columns.Add(new Column() { Index = 4, Value = RandomDecimal() });
                columns.Add(new Column() { Index = 5, Value = RandomDecimal() });
                columns.Add(new Column() { Index = 6, CellDataType = CellDataType.DecimalRedPositive, Value = (i % 2 == 0 ? 1 : -1) * RandomDecimal() });
                columns.Add(new Column() { Index = 7, CellDataType = CellDataType.Percentage, Value = RandomMargin() });
                rows.Add(new Row() { Columns = columns, RowIndex = i });
            }

            return rows;
        }

        /// <summary>
        /// GET BODY ROWS.
        /// </summary>
        /// <param name="numOfRow">NUMBER OF ROWS.</param>
        /// <returns>LIST OF ROW.</returns>
        private List<Row> GetBodyRowsWithLink(int numOfRow)
        {
            var rows = new List<Row>();
            for (int i = 0; i < numOfRow; i++)
            {
                var value = RandomText();
                var param = new List<LinkParameter>() { new LinkParameter() { Value = i, IsNumber = true }, new LinkParameter() { Value = value } };
                var linkInfo = new LinkInformation() { DisplayText = value, FunctionName = "functionName", Parameters = param };
                var link = RenderLink.Render(linkInfo);
                var columns = new List<Column>();
                columns.Add(new Column() { Index = 0, TextAlign = TextAlign.Center, CellDataType = CellDataType.Integer, Value = i + 1 });
                columns.Add(new Column() { Index = 1, TextAlign = TextAlign.Center, CellDataType = CellDataType.DateTimeMMMdyyyy, Value = RandomDate() });
                columns.Add(new Column() { Index = 2, TextAlign = TextAlign.Left, CellDataType = CellDataType.Link, Value = link });
                columns.Add(new Column() { Index = 3, CellDataType = CellDataType.Integer, Value = RandomInt() });
                columns.Add(new Column() { Index = 4, Value = RandomDecimal() });
                columns.Add(new Column() { Index = 5, Value = RandomDecimal() });
                columns.Add(new Column() { Index = 6, CellDataType = CellDataType.DecimalRedPositive, Value = (i % 2 == 0 ? 1 : -1) * RandomDecimal() });
                columns.Add(new Column() { Index = 7, CellDataType = CellDataType.Percentage, Value = RandomMargin() });
                rows.Add(new Row() { Columns = columns, RowIndex = i });
            }

            return rows;
        }

        /// <summary>
        /// GET FOOTER ROWS.
        /// </summary>
        /// <returns>LIST OF ROW.</returns>
        private List<Row> GetFooterRows()
        {
            var rows = new List<Row>();
            for (int i = 0; i < 4; i++)
            {
                var mergeRow = i == 0 ? 4 : 1;
                var columns = new List<Column>();
                columns.Add(new Column()
                {
                    Index = 0,
                    TextAlign = TextAlign.Center,
                    CellDataType = CellDataType.Text,
                    Value = "Total",
                    MergeColumnNumber = 2,
                    MergeRowNumber = mergeRow
                });
                columns.Add(new Column() { Index = 1, TextAlign = TextAlign.Center, CellDataType = CellDataType.Text, Value = "Total" });
                columns.Add(new Column() { Index = 2, TextAlign = TextAlign.Left, CellDataType = CellDataType.Text, Value = RandomText(), });
                columns.Add(new Column() { Index = 3, TextAlign = TextAlign.Right, CellDataType = CellDataType.Integer, Value = RandomInt(), });
                columns.Add(new Column() { Index = 4, TextAlign = TextAlign.Right, CellDataType = CellDataType.Decimal, Value = RandomDecimal(), });
                columns.Add(new Column() { Index = 5, TextAlign = TextAlign.Right, CellDataType = CellDataType.Decimal, Value = RandomDecimal(), });
                columns.Add(new Column() { Index = 6, TextAlign = TextAlign.Right, CellDataType = CellDataType.DecimalRedNegative, Value = RandomDecimal(), });
                columns.Add(new Column() { Index = 7, TextAlign = TextAlign.Right, CellDataType = CellDataType.Percentage, Value = RandomMargin(), });
                rows.Add(new Row() { Columns = columns, RowIndex = i });
            }

            return rows;
        }

        private string RandomText()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }

        private int RandomInt()
        {
            return new Random().Next(1, 10000000);
        }

        private decimal RandomDecimal()
        {
            return (decimal)(RandomInt() * new Random().NextDouble());
        }

        private decimal RandomMargin()
        {
            return (decimal)new Random().NextDouble();
        }

        private DateTime RandomDate()
        {
            var random = new Random();
            return new DateTime(random.Next(2000, 2015), random.Next(1, 12), random.Next(1, 28));
        }
    }
}