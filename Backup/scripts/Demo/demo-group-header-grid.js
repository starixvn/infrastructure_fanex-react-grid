/* File Created: March 10, 2015 */
function getReactDynamic(){
    React.render(
        <ReactGrid dataUrl={getClientUrl("demo/getdata?numOfRow=" + document.getElementById("num-of-row").value)} containerId='react-grid' pagingCallBackFunction={getJsonDataCallBackReactSystax} />,
        document.getElementById('react-grid')
    );
}
// React syntax
function getJsonDataReactSyntax() {
   
    var criteria = new FormData();
    criteria.append('numOfRow', $("#num-of-row").val());
    var xhr = new XMLHttpRequest();
    xhr.open('post', getClientUrl("demo/FirstPage"), true);
    xhr.onload = function () {
        var result = JSON.parse(xhr.responseText);
        renderReportReactSyntax(result);
    };
    xhr.send(criteria);

}

function renderReportReactSyntax(gridOptions) {
    
    //gridOptions.PagingOptions.PagingCallBack = getJsonDataCallBackReactSystax;

    React.render(
        <ReactGrid gridOptions={gridOptions} containerId='react-grid-1' />,
        document.getElementById('react-grid-1')
    );
}

function getJsonDataCallBackReactSystax(pageIndex, pageSize) {
    var result;
    var criteria = new FormData();
    criteria.append('numOfRow', $("#num-of-row").val());
    criteria.append('pageIndex', pageIndex);
    criteria.append('pageSize', pageSize);
    var xhr = new XMLHttpRequest();
    xhr.open('post', getClientUrl("demo/FirstPage"), false);
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
        GroupHeaders: [
            {"Index":0,"Name":"ColumnIndex","MergeRowNumber":2,"Text":"#","TextAlign":2,"TdClass":null},
            {"Index":1,"Name":"ColumnDate","MergeRowNumber":2,"Text":"Date","TextAlign":2,"TdClass":null},
            {"Index":2,"Name":"ColumnText","MergeRowNumber":2,"Text":"Text","TextAlign":2,"TdClass":null},
            {"Index":3,"Name":"ColumnInteger","MergeColumnNumber":2,"Text":"Number","TextAlign":2,"TdClass":null},            
            {"Index":5,"Name":"ColumnPercentage","MergeRowNumber":2,"Text":"Percentage","TextAlign":2,"TdClass":null}
        ],
        HeaderColumns: [
            {"Index":3,"Name":"ColumnInteger","Text":"Integer","TextAlign":2,"TdClass":null},
            {"Index":4,"Name":"ColumnDecimal","Text":"Decimal","TextAlign":2,"TdClass":null},            
        ],
        BodyRows: generateData(document.getElementById("num-of-row").value),
        FooterRows: []
    };
    
    React.render(
        <ReactGrid gridOptions={gridOptions} containerId='react-grid' />,
        document.getElementById('react-grid-client')
    );
}

function generateData(numOfRows){
    var bodyRows = [];
    for(var i = 0; i< numOfRows;i++){
        var columns = [
            {"Index":0,"Name":"ColumnIndex","Value":1,"IsHightLight":false,"TextAlignment":"center","CellClass":"","DisplayText":i+1},
            {"Index":1,"Name":"ColumnDate","Value":"/Date(950547600000)/","IsHightLight":false,"TextAlignment":"center","CellClass":"","DisplayText":"Feb 15, 2000"},
            {"Index":2,"Name":"ColumnText","Value":"041bb9832-1494-4bee-8529-70c29bc3026f","IsHightLight":false,"TextAlignment":"left","CellClass":"","DisplayText":"041bb9832-1494-4bee-8529-70c29bc3026f"},
            {"Index":3,"Name":"ColumnInteger","Value":330243,"IsHightLight":false,"TextAlignment":"right","CellClass":"","DisplayText":"330,243"},
            {"Index":4,"Name":"ColumnDecimal","Value":10906.0248046955,"IsHightLight":false,"TextAlignment":"right","CellClass":"","DisplayText":"10,906.02"},
            {"Index":5,"Name":"ColumnPercentage","Value":0.0330242421631814,"IsHightLight":false,"TextAlignment":"right","CellClass":"","DisplayText":"330.24%"}
        ];
        var row = {
            RowIndex: i,
            Columns: columns
        };
        bodyRows.push(row);
    }

    return bodyRows;
}