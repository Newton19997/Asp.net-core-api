
var id = 0;
$("#AddButton").click(() => {
    var productId = $("#productId").val();
    var productName = $("#productId option:selected").text();
    var UnitPrice = $("#UnitPrice").val();
    var Qty = $("#Qty").val();
    var DiscountPercentage = $("#DiscountPercentage").val();
   

    var tr = '<tr>';
    var prod = '<td><input type="hidden" name="OrderDetails[' + id +'].ProductId" value="'+productId+'"/>' + productName+'</td>';
    var Qtyd = '<td><input type="hidden" name="OrderDetails[' + id + '].Qty" value="'+ Qty+'" />' + Qty+'</td>';
    var UPd = '<td><input type="hidden" name="OrderDetails[' + id + '].UnitPrice" value="'+ UnitPrice + '"/>' + UnitPrice+'</td>';
    var dpd = '<td><input type="hidden" name="OrderDetails[' + id + '].DiscountPercentage" value="'+ DiscountPercentage+'"/>' + DiscountPercentage + '</td>';

    tr += prod + Qtyd + UPd + dpd + '</tr>';

    $("#tbOrderDetails").append(tr);
    id++;
});