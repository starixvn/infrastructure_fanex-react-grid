/* File Created: March 10, 2015 */
"use strict"
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