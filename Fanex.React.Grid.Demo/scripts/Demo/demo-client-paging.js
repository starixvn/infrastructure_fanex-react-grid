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
        ShowTitle: false,
        TitleText: '',
        NoDataText: "No data.",
        ShowFooter: false,
        OddEvenRow: false,
        IsHighlightHover: false,
        IsPaging: true,
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
            {"Index":0,"Name":"ColumnIndex","Width":60,"MergeColumnNumber":1,"MergeRowNumber":1,"Text":"#","TextAlign":2,"TdClass":null},
            {"Index":1,"Name":"ColumnDate","Width":100,"MergeColumnNumber":1,"MergeRowNumber":1,"Text":"Date","TextAlign":2,"TdClass":null},
            {"Index":2,"Name":"ColumnText","Width":250,"MergeColumnNumber":1,"MergeRowNumber":1,"Text":"Text","TextAlign":2,"TdClass":null},
            {"Index":3,"Name":"ColumnInteger","Width":100,"MergeColumnNumber":1,"MergeRowNumber":1,"Text":"Integer","TextAlign":2,"TdClass":null},
            {"Index":4,"Name":"ColumnDecimal","Width":150,"MergeColumnNumber":1,"MergeRowNumber":1,"Text":"Decimal","TextAlign":2,"TdClass":null},
            {"Index":5,"Name":"ColumnPercentage","Width":150,"MergeColumnNumber":1,"MergeRowNumber":1,"Text":"Percentage","TextAlign":2,"TdClass":null}
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
            {"Index":0,"Name":"ColumnIndex","Value":1,"MergeColumnNumber":1,"MergeRowNumber":1,"IsHightLight":false,"TextAlignment":"center","CellClass":"","DisplayText":i+1},
            {"Index":1,"Name":"ColumnDate","Value":"/Date(950547600000)/","MergeColumnNumber":1,"MergeRowNumber":1,"IsHightLight":false,"TextAlignment":"center","CellClass":"","DisplayText":"Feb 15, 2000"},
            {"Index":2,"Name":"ColumnText","Value":"041bb9832-1494-4bee-8529-70c29bc3026f","MergeColumnNumber":1,"MergeRowNumber":1,"IsHightLight":false,"TextAlignment":"left","CellClass":"","DisplayText":"041bb9832-1494-4bee-8529-70c29bc3026f"},
            {"Index":3,"Name":"ColumnInteger","Value":330243,"MergeColumnNumber":1,"MergeRowNumber":1,"IsHightLight":false,"TextAlignment":"right","CellClass":"","DisplayText":"330,243"},
            {"Index":4,"Name":"ColumnDecimal","Value":10906.0248046955,"MergeColumnNumber":1,"MergeRowNumber":1,"IsHightLight":false,"TextAlignment":"right","CellClass":"","DisplayText":"10,906.02"},
            {"Index":5,"Name":"ColumnPercentage","Value":0.0330242421631814,"MergeColumnNumber":1,"MergeRowNumber":1,"IsHightLight":false,"TextAlignment":"right","CellClass":"","DisplayText":"330.24%"}
        ];
        var row = {
            RowIndex: i,
            Columns: columns
        };
        bodyRows.push(row);
    }

    return bodyRows;
}