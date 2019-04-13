/* JS Document */

function Comprar(evt) {
    var id = evt.target.id;
    var path = "/Carrito/Create";
    $.ajax({
        type: "POST",
        cache: false,
        url: path,
        data: '{"producto_id": "' + id + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            data = JSON.parse(data);
            var compra = document.getElementsByClassName('cart_count')[0].children[0];
            var total = document.getElementsByClassName('cart_price')[0];
            var numero = parseInt(compra.innerText);
            if (data.Estado == "Success++") {
                numero++;
                compra.innerText = numero + "";
            }
            total.innerText = "₡ " + data.Total;
        },
        error: function () {
            alert(data);
        }
    });
}