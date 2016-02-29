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
   hideDemo();
    var criteria = new FormData();
    criteria.append('numOfRow', $("#num-of-row").val());
    var xhr = new XMLHttpRequest();
    xhr.open('post', getClientUrl("Utility/SortDataData"), true);
    xhr.onload = function () {
        var gridOptions = JSON.parse(xhr.responseText);
        React.render(
            <ReactGrid gridOptions={gridOptions} containerId='react-grid-server' />,
            document.getElementById('react-grid-server')
        );
    };
    xhr.send(criteria);

}
function functionName(param)
{
    alert(param.id+" "+param.name);   
}
function getGridOptionsFromClient() {
    hideDemo();
    var gridOptions = {
        ShowTitle: false,
        TitleText: '',
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
        SortColumnList : [1, 2, 3, 4, 5],
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
        var linkInfo = {
            DisplayText : "link render text",
            FunctionName : "functionName",
            ClassName : "demo-link-class",
            Parameters : [
                {
                    Name : "id", Value : i
                },
                {
                    Name : "name", Value : "text param"
                }
            ]
        };
        var columns = [
            {"Index":0,"CellDataType":CellDataType.Integer,"Value":i+1,"TextAlignment":"center","CellClass":"","IsRowIndex": true},
            {"Index":1,"CellDataType":CellDataType.DateTimeMMMdyyyy,"Value":new Date((i%12+1)+"/" + (i%28+1) +"/2015"),"TextAlignment":"center","CellClass":""},
            {"Index":2,"CellDataType":CellDataType.Text,"Value":texts[i%10],"TextAlignment":"left","CellClass":""},
            {"Index":3,"CellDataType":CellDataType.Integer,"Value":330243 * (i%10),"TextAlignment":"right","CellClass":""},
            {"Index":4,"CellDataType":CellDataType.DecimalRedPositive,"Value":10906.0248046955 * (i%10),"TextAlignment":"right","CellClass":""},
            {"Index":5,"CellDataType":CellDataType.PercentageRedNegative,"Value":0.0330242421631814 * (i%10),"TextAlignment":"right","CellClass":""}
        ];
        var row = {
            RowIndex: i,
            Columns: columns
        };
        bodyRows.push(row);
    }

    return bodyRows;
}

var texts=["12668c04f474a434b86c6fabea3a9cc06","2ecf59db64f184828bec93e2d5d65aae9","079e20e964c3946a9b7aa27003d32bc75","59012c274a090462f911fda01951a9958","94140c93b394542008d533ff401ce64b9","17b6d1ddfee465403a825dc41d5504a5c0","15d54f5e9627914f4f90e3631d8ef914d8","13d757e9c9c5984eb3a3bd50d48c35f791","243360e62ae1fd465ca7f6db176ebda073","289385fb74033a442fb886ed22e315dd7f"];