namespace Fanex.React.Grid.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fanex.React.Options.Core;
    using Fanex.React.Options.Formatter;

    /// <summary>
    /// FIRST PAGE SERVICE.
    /// </summary>
    public class FirstPageService
    {
        /// <summary>
        /// GET REACT GRID OPTIONS.
        /// </summary>
        /// <param name="numOfRow">NUMBER OF ROWS.</param>
        /// <returns>GRID OPTIONS.</returns>
        public GridOptions GetReactGridOptions(int numOfRow)
        {
            var bodyRows = GetBodyRows(numOfRow);
            var gridOptions = new GridOptions
            {
                NoDataText = "No data",
                MaxContentHeight = 250,
                HeaderStyle = Fanex.React.Options.Formatter.HeaderStyle.HeaderOneLine,
                HeaderColumns = GetHeader(),
                BodyRows = bodyRows,
                FooterRows = GetFooterRows(),
                ColumnWidthList = new List<int> { 60, 100, 250, 100, 150, 150 }
            };

            return gridOptions;
        }

        /// <summary>
        /// GET REACT GRID OPTIONS.
        /// </summary>
        /// <param name="numOfRow">NUMBER OF ROW.</param>
        /// <param name="pageIndex">PAGE INDEX.</param>
        /// <param name="pageSize">PAGE SIZE.</param>
        /// <returns>GRID OPTIONS.</returns>
        public GridOptions GetPagingGridOptions(int numOfRow, int pageIndex = 0, int pageSize = 100)
        {
            var bodyRows = GetBodyRows(numOfRow);
            var pagingBodyRows = bodyRows.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var gridOptions = new GridOptions
            {
                NoDataText = "No data",
                MaxContentHeight = 250,
                IsPaging = true,
                IsServerPaging = true,
                PagingOptions = new PagingOptions
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    PageSizeList = new List<int> { 50, 100, 200, 500 },
                    TotalItems = bodyRows.Count,
                },
                HeaderColumns = GetHeader(),
                BodyRows = pagingBodyRows,
                FooterRows = GetFooterRows(),
                ColumnWidthList = new List<int> { 60, 100, 250, 100, 150, 150 }
            };

            return gridOptions;
        }

        /// <summary>
        /// GET REACT GRID OPTIONS.
        /// </summary>
        /// <param name="numOfRow">NUMBER OF ROW.</param>
        /// <returns>GRID OPTIONS.</returns>
        public GridOptions GetMergeColumnGridOptions(int numOfRow)
        {
            var bodyRows = GetBodyMergeColumnRows(numOfRow);
            var gridOptions = new GridOptions
            {
                NoDataText = "No data",
                MaxContentHeight = 250,
                ShowFooter = true,
                HeaderColumns = GetHeader(),
                BodyRows = bodyRows,
                FooterRows = GetFooterMergeColumnRows(),
                ColumnWidthList = new List<int> { 60, 100, 250, 100, 150, 150 }
            };

            return gridOptions;
        }

        /// <summary>
        /// GET REACT GRID OPTIONS.
        /// </summary>
        /// <param name="numOfRow">NUMBER OF ROWS.</param>
        /// <param name="startIndex">PAGE INDEX.</param>
        /// <param name="endIndex">PAGE SIZE.</param>
        /// <returns>GRID OPTIONS.</returns>
        public GridOptions GetLargeGridOptions(int numOfRow, int startIndex = 0, int endIndex = 100)
        {
            var bodyRows = GetLageDataBodyRows(numOfRow, startIndex, endIndex);
            var gridOptions = new GridOptions
            {
                NoDataText = "No data",
                MaxContentHeight = 250,
                IsRenderLargeData = true,
                HeaderStyle = Fanex.React.Options.Formatter.HeaderStyle.HeaderOneLine,
                HeaderColumns = GetHeader(),
                BodyRows = bodyRows,
                FooterRows = GetFooterRows(),
                ColumnWidthList = new List<int> { 60, 100, 250, 100, 150, 150 }
            };

            return gridOptions;
        }

        /// <summary>
        /// GET BODY ROWS.
        /// </summary>
        /// <param name="numOfRow">NUMBER OF ROWS.</param>
        /// <param name="startIndex">PAGE INDEX.</param>
        /// <param name="endIndex">PAGE SIZE.</param>
        /// <returns>LIST OF ROW.</returns>
        private List<Row> GetLageDataBodyRows(int numOfRow, int startIndex = 0, int endIndex = 100)
        {
            var rows = new List<Row>();
            var maxIndex = Math.Min(endIndex, numOfRow);
            for (int i = startIndex; i < maxIndex; i++)
            {
                var colindex = 0;
                var columns = new List<Column>();
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Center, CellDataType = CellDataType.Integer, Value = i + 1 });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Center, CellDataType = CellDataType.DateTimeMMMdyyyy, Value = RandomDate() });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Left, CellDataType = CellDataType.Text, Value = i.ToString() + RandomText() });
                columns.Add(new Column() { Index = colindex++, CellDataType = CellDataType.Integer, Value = RandomInt() });
                columns.Add(new Column() { Index = colindex++, CellDataType = CellDataType.Decimal, Value = (i % 2 == 0 ? 1 : -1) * RandomDecimal() });
                columns.Add(new Column() { Index = colindex++, CellDataType = CellDataType.Percentage, Value = RandomMargin() });
                rows.Add(new Row() { Columns = columns, RowIndex = i });
            }

            return rows;
        }

        /// <summary>
        /// GET HEADER.
        /// </summary>
        /// <returns>HEADER COLUMNS.</returns>
        private List<HeaderColumns> GetHeader()
        {
            var headers = new List<HeaderColumns>();
            var colindex = 0;

            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnIndex", TextAlign = TextAlign.Center, Text = "#", Width = 60 });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnDate", TextAlign = TextAlign.Center, Text = "Date", Width = 100 });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnText", TextAlign = TextAlign.Center, Text = "Text", Width = 250 });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnInteger", TextAlign = TextAlign.Center, Text = "Integer", Width = 100 });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnDecimal", TextAlign = TextAlign.Center, Text = "Decimal", Width = 150 });
            headers.Add(new HeaderColumns { Index = colindex++, Name = "ColumnPercentage", TextAlign = TextAlign.Center, Text = "Percentage", Width = 150 });

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
                columns.Add(new Column() { Index = colindex++, CellDataType = CellDataType.Decimal, Value = (i % 2 == 0 ? 1 : -1) * RandomDecimal() });
                columns.Add(new Column() { Index = colindex++, CellDataType = CellDataType.Percentage, Value = RandomMargin() });
                rows.Add(new Row() { Columns = columns, RowIndex = i });
            }

            return rows;
        }

        /// <summary>
        /// GET FOOTER ROW.
        /// </summary>
        /// <returns>LIST OF ROW.</returns>
        private List<Row> GetFooterRows()
        {
            var rows = new List<Row>();
            for (int i = 0; i < 1; i++)
            {
                var colindex = 0;
                var columns = new List<Column>();
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Center, CellDataType = CellDataType.Text, Value = "Total" });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Center, CellDataType = CellDataType.DateTimeMMMdyyyy, Value = RandomDate() });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Right, CellDataType = CellDataType.Text, Value = RandomText() });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Right, CellDataType = CellDataType.Integer, Value = RandomInt() });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Right, CellDataType = CellDataType.Decimal, Value = RandomDecimal(), });
                columns.Add(new Column() { Index = colindex++, TextAlign = TextAlign.Right, CellDataType = CellDataType.Percentage, Value = RandomMargin(), });
                rows.Add(new Row() { Columns = columns, RowIndex = i });
            }

            return rows;
        }

        /// <summary>
        /// GET BODY ROWS.
        /// </summary>
        /// <param name="numOfRow">NUMBER OF ROWS.</param>
        /// <returns>LIST OF ROW.</returns>
        private List<Row> GetBodyMergeColumnRows(int numOfRow)
        {
            var rows = new List<Row>();
            for (int i = 0; i < numOfRow; i++)
            {
                var mergeRowNumber = i % 10 == 0 && i < numOfRow - 4 ? 3 : 1;
                var columns = new List<Column>();
                columns.Add(new Column() { Index = 0, TextAlign = TextAlign.Center, CellDataType = CellDataType.Integer, Value = i + 1 });
                columns.Add(new Column()
                {
                    Index = 1,
                    TextAlign = TextAlign.Center,
                    CellDataType = CellDataType.DateTimeMMMdyyyy,
                    Value = RandomDate(),
                    MergeRowNumber = mergeRowNumber
                });
                columns.Add(new Column() { Index = 2, TextAlign = TextAlign.Left, CellDataType = CellDataType.Text, Value = i.ToString() + RandomText() });
                columns.Add(new Column() { Index = 3, CellDataType = CellDataType.Integer, Value = RandomInt(), MergeRowNumber = mergeRowNumber });
                columns.Add(new Column() { Index = 4, CellDataType = CellDataType.Decimal, Value = (i % 2 == 0 ? 1 : -1) * RandomDecimal() });
                columns.Add(new Column() { Index = 5, CellDataType = CellDataType.Percentage, Value = RandomMargin() });
                rows.Add(new Row() { Columns = columns, RowIndex = i });
            }

            return rows;
        }

        /// <summary>
        /// GET FOOTER ROW.
        /// </summary>
        /// <returns>LIST OF ROW.</returns>
        private List<Row> GetFooterMergeColumnRows()
        {
            var rows = new List<Row>();
            for (int i = 0; i < 3; i++)
            {
                var mergeRowNumber = i == 0 ? 3 : 1;
                var columns = new List<Column>();
                columns.Add(new Column()
                {
                    Index = 0,
                    TextAlign = TextAlign.Center,
                    CellDataType = CellDataType.Text,
                    Value = "Total",
                    MergeColumnNumber = 2,
                    MergeRowNumber = mergeRowNumber
                });
                columns.Add(new Column() { Index = 2, TextAlign = TextAlign.Left, CellDataType = CellDataType.Text, Value = RandomText() });
                columns.Add(new Column() { Index = 3, TextAlign = TextAlign.Right, CellDataType = CellDataType.Integer, Value = RandomInt() });
                columns.Add(new Column()
                {
                    Index = 4,
                    TextAlign = TextAlign.Right,
                    CellDataType = CellDataType.Decimal,
                    Value = RandomDecimal(),
                    MergeRowNumber = mergeRowNumber
                });
                columns.Add(new Column() { Index = 5, TextAlign = TextAlign.Right, CellDataType = CellDataType.Percentage, Value = RandomMargin(), });
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