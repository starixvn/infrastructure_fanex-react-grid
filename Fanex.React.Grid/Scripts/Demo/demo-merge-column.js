function getFullData() {
   
    var criteria = new FormData();
    criteria.append('numOfRow', $("#num-of-row").val());
    var xhr = new XMLHttpRequest();
    xhr.open('post', getClientUrl("demo/FirstPage"), true);
    xhr.onload = function () {
        var result = JSON.parse(xhr.responseText);
        console.log(result);
    };
    xhr.send(criteria);

}

function getGridOptionsFromServer() {
   
    var criteria = new FormData();
    criteria.append('numOfRow', $("#num-of-row").val());
    var xhr = new XMLHttpRequest();
    xhr.open('post', getClientUrl("demo/MergeColumnData"), true);
    xhr.onload = function () {
        var gridOptions = JSON.parse(xhr.responseText);
        
        React.render(
            <ReactGrid gridOptions={gridOptions} containerId='react-grid' />,
            document.getElementById('react-grid-server')
        );
    };
    xhr.send(criteria);

}

function getDataPagingCallBack(pageIndex, pageSize) {
    var result;
    var criteria = new FormData();
    criteria.append('numOfRow', $("#num-of-row").val());
    criteria.append('pageIndex', pageIndex);
    criteria.append('pageSize', pageSize);
    var xhr = new XMLHttpRequest();
    xhr.open('post', getClientUrl("demo/ServerPagingData"), false);
    xhr.onreadystatechange  = function () {

        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
               result = JSON.parse(xhr.responseText);               
            }
        }
    };
    xhr.send(criteria);

    return result;
}

function getGridOptionsFromClient() {
    var gridOptions = {
        ShowTitle: false,
        TitleText: '',
        NoDataText: "No data.",
        ShowFooter: true,
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
            {"Index":0,"Name":"ColumnIndex","Text":"#","TextAlign":2,"TdClass":null},
            {"Index":1,"Name":"ColumnDate","Width":100,"MergeColumnNumber":1,"MergeRowNumber":1,"Text":"Date","TextAlign":2,"TdClass":null},
            {"Index":2,"Name":"ColumnText","Width":250,"MergeColumnNumber":1,"MergeRowNumber":1,"Text":"Text","TextAlign":2,"TdClass":null},
            {"Index":3,"Name":"ColumnInteger","Width":100,"MergeColumnNumber":1,"MergeRowNumber":1,"Text":"Integer","TextAlign":2,"TdClass":null},
            {"Index":4,"Name":"ColumnDecimal","Width":150,"MergeColumnNumber":1,"MergeRowNumber":1,"Text":"Decimal","TextAlign":2,"TdClass":null},
            {"Index":5,"Name":"ColumnPercentage","Width":150,"MergeColumnNumber":1,"MergeRowNumber":1,"Text":"Percentage","TextAlign":2,"TdClass":null}
        ],
        BodyRows: generateData(document.getElementById("num-of-row").value),
        FooterRows: generateFooter()
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
        var mergeRowNumber = i % 10 == 0 && i < numOfRows - 4 ? 3 : 1;
        var mergeColumnNumber = i % 10 == 0 ? 3 : 1;
        var columns = [
            {"Index":0,"CellDataType":CellDataType.Integer,"Value":i+1,"TextAlignment":"center"},
            {"Index":1,"CellDataType":CellDataType.DateTimeMMMdyyyy,"Value":"01/02/2015","TextAlignment":"center","MergeRowNumber":mergeRowNumber},
            {"Index":2,"CellDataType":CellDataType.Text,"Value":"041bb9832-1494-4bee-8529-70c29bc3026f","TextAlignment":"left","MergeColumnNumber":mergeColumnNumber},
            {"Index":3,"CellDataType":CellDataType.Integer,"Value":330243,"TextAlignment":"right"},
            {"Index":4,"CellDataType":CellDataType.DecimalRedPositive,"Value":10906.0248046955,"TextAlignment":"right"},
            {"Index":5,"CellDataType":CellDataType.PercentageRedNegative,"Value":0.0330242421631814,"TextAlignment":"right"}
        ];
        var row = {
            RowIndex: i,
            Columns: columns
        };
        bodyRows.push(row);
    }

    return bodyRows;
}

function generateFooter(){
    var footerRows = [];
    for(var i = 0; i< 2;i++){
        var mergeRows = i==0?2:1;
        var columns = [
            {"Index":0,"Value":1,"MergeColumnNumber":2,"MergeRowNumber":mergeRows,"TextAlignment":"center","DisplayText":"Total"},
            {"Index":1,"Value":1,"TextAlignment":"center","DisplayText":"Total"},
            {"Index":2,"Value":"","TextAlignment":"left","DisplayText":"041bb9832-1494-4bee-8529-70c29bc3026f"},
            {"Index":3,"Value":330243,"TextAlignment":"right","DisplayText":"330,243"},
            {"Index":4,"Value":10906.0248046955,"TextAlignment":"right","DisplayText":"10,906.02"},
            {"Index":5,"Value":0.0330242421631814,"TextAlignment":"right","DisplayText":"330.24%"}
        ];
        var row = {
            RowIndex: i,
            Columns: columns
        };
        footerRows.push(row);
    }

    return footerRows;
}