
function getGridOptionsFromServer() {
   
    var criteria = new FormData();
    criteria.append('numOfRow', $("#num-of-row").val());
    var xhr = new XMLHttpRequest();
    xhr.open('post', getClientUrl("demo/FirstPage"), true);
    xhr.onload = function () {
        var gridOptions = JSON.parse(xhr.responseText);
        React.render(
            <ReactGrid gridOptions={gridOptions} containerId='react-grid' />,
            document.getElementById('react-grid-server')
        );
    };
    xhr.send(criteria);

}

function getGridOptionsFromClient() {
    var gridOptions = {
        ShowTitle: true,
        IsExportExcel: true,
        ExportExcelFunction: exportExcelFunction,
        TitleText: 'Grid - show title - demo',
        NoDataText: "No data.",
        ShowFooter: false,
        OddEvenRow: false,
        IsHighlightHover: false,
        IsPaging: false,
        IsServerPaging: false,
        PagingOptions: {
            PageIndex: 0,
            PageSize: 100,
            PageSizeList: [50, 100, 200, 500],
            PagingCallBack: null,
            NumberOfPage: 0,
            TotalItems: 0
        },
        MaxContentHeight: 250,
        MaxContentWidth: 1000,
        GridWidth: 0,
        ColumnWidthList: [60,100,250,100,150,150],
        HeaderStyle: 1,
        GroupHeaders: [],
        HeaderColumns: [
            {"Index":0,"Text":"#","TdClass":null},
            {"Index":1,"Text":"Date","TdClass":null},
            {"Index":2,"Text":"Text","TdClass":null},
            {"Index":3,"Text":"Integer","TdClass":null},
            {"Index":4,"Text":"Decimal","TdClass":null},
            {"Index":5,"Text":"Percentage","TdClass":null}
        ],
        BodyRows: generateData(document.getElementById("num-of-row").value),
        FooterRows: []
    };
    
    React.render(
        <ReactGrid gridOptions={gridOptions} containerId='react-grid' />,
        document.getElementById('react-grid-client')
    );
}

function hideDemo(){
    document.getElementById('react-grid-server').innerHTML = "";
    document.getElementById('react-grid-client').innerHTML = "";
}

function generateData(numOfRows){
    var bodyRows = [];
    for(var i = 0; i< numOfRows;i++){
        var columns = [
            {"Index":0,"CellDataType":CellDataType.Integer,"Value":i+1,"TextAlignment":"center","CellClass":""},
            {"Index":1,"CellDataType":CellDataType.DateTimeMMMdyyyy,"Value":"01/02/2015","TextAlignment":"center","CellClass":""},
            {"Index":2,"CellDataType":CellDataType.Text,"Value":"041bb9832-1494-4bee-8529-70c29bc3026f","TextAlignment":"left","CellClass":""},
            {"Index":3,"CellDataType":CellDataType.Integer,"Value":330243,"TextAlignment":"right","CellClass":""},
            {"Index":4,"CellDataType":CellDataType.DecimalRedPositive,"Value":10906.0248046955,"TextAlignment":"right","CellClass":""},
            {"Index":5,"CellDataType":CellDataType.PercentageRedNegative,"Value":0.0330242421631814,"TextAlignment":"right","CellClass":""}
        ];
        var row = {
            RowIndex: i,
            Columns: columns
        };
        bodyRows.push(row);
    }

    return bodyRows;
}

var exportExcelFunction = function(){
    alert("Excel");
}