namespace Fanex.React.Grid.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fanex.React.Options.Core;
    using Fanex.React.Options.Formatter;

    /// <summary>
    /// DEMO SERVICE.
    /// </summary>
    public class DemoService
    {
        /// <summary>
        /// GET REACT GRID OPTIONS.
        /// </summary>
        /// <param name="numOfRow">NUMBER OF ROW.</param>
        /// <param name="pageIndex">PAGE INDEX.</param>
        /// <param name="pageSize">PAGE SIZE.</param>
        /// <returns>GRID OPTIONS.</returns>
        public GridOptions GetReactGridOptions(int numOfRow, int pageIndex = 0, int pageSize = 100)
        {
            var bodyRows = GetBodyRows(numOfRow);
            var pagingBodyRows = bodyRows.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var gridOptions = new GridOptions
            {
                ShowTitle = true,
                TitleText = "Grid demo",
                NoDataText = "No data",
                ShowFooter = true,
                MaxContentHeight = 250,
                OddEvenRow = true,
                IsHighlightHover = true,
                HeaderStyle = Fanex.React.Options.Formatter.HeaderStyle.HeaderOneLine,
                IsPaging = true,
                IsServerPaging = true,
                PagingOptions = new PagingOptions() { TotalItems = bodyRows.Count, PageIndex = pageIndex, PageSize = pageSize },
                GroupHeaders = GetGroupHeader(),
                HeaderColumns = GetHeader(),
                BodyRows = pagingBodyRows,
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
            var colindex = 0;

            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnIndex", TextAlign = TextAlign.Center, Text = "#", MergeRowNumber = 2 });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnDate", TextAlign = TextAlign.Center, Text = "Date", MergeRowNumber = 2 });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnUsername", TextAlign = TextAlign.Center, Text = "Username", MergeRowNumber = 2 });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnBetCount", TextAlign = TextAlign.Center, Text = "Bet Count", MergeRowNumber = 2 });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnTurnover", TextAlign = TextAlign.Center, Text = "Turnover", MergeColumnNumber = 3 });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnMargin", TextAlign = TextAlign.Center, Text = "Margin", MergeRowNumber = 2 });

            return headers;
        }

        private List<HeaderColumns> GetHeader()
        {
            var headers = new List<HeaderColumns>();
            var colindex = 0;

            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnTurnover", TextAlign = TextAlign.Center, Text = "Turnover", });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnCustomerWL", TextAlign = TextAlign.Center, Text = "Customer W/L", });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnLicenseeWL", TextAlign = TextAlign.Center, Text = "Licensee W/L", });

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
                var colindex = 0;
                var columns = new List<Column>();
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Center, CellDataType = CellDataType.Integer, Value = i + 1 });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Center, CellDataType = CellDataType.DateTimeMMMdyyyy, Value = RandomDate() });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Left, CellDataType = CellDataType.Text, Value = i.ToString() + RandomText() });
                columns.Add(new Column() { Index = colindex++, CellDataType = CellDataType.Integer, Value = RandomInt() });
                columns.Add(new Column() { Index = colindex++, Value = RandomDecimal() });
                columns.Add(new Column() { Index = colindex++, Value = RandomDecimal() });
                columns.Add(new Column() { Index = colindex++, CellDataType = CellDataType.DecimalRedPositive, Value = (i % 2 == 0 ? 1 : -1) * RandomDecimal() });
                columns.Add(new Column() { Index = colindex++, CellDataType = CellDataType.Percentage, Value = RandomMargin() });
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
            for (int i = 0; i < 2; i++)
            {
                var colindex = 0;
                var columns = new List<Column>();
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Center, CellDataType = CellDataType.Text, Value = "Total", MergeColumnNumber = 2 });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Left, CellDataType = CellDataType.Text, Value = RandomText(), });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Right, CellDataType = CellDataType.Integer, Value = RandomInt(), });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Right, CellDataType = CellDataType.Decimal, Value = RandomDecimal(), });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Right, CellDataType = CellDataType.Decimal, Value = RandomDecimal(), });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Right, CellDataType = CellDataType.DecimalRedNegative, Value = RandomDecimal(), });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Right, CellDataType = CellDataType.Percentage, Value = RandomMargin(), });
                rows.Add(new Row() { Columns = columns, RowIndex = i });
            }

            return rows;
        }

        private string RandomText()
        {
            return Guid.NewGuid().ToString();
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