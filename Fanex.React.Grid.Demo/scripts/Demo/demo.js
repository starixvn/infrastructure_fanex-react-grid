/* File Created: March 31, 2015 */
$(document).ready(function () {
    var num = 0;
    $("#num-of-row").keypress(function (e) {
        num = $("#num-of-row").val();
    });
    $("#num-of-row").keyup(function (e) {
        var a = $("#num-of-row").val();
        if (a > 10000) {
            $("#num-of-row").val(num);
        }
    });
});