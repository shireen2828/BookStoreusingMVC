function placeOrder() {

    var placeOrder = document.getElementById('Placeorder_btn');
    placeOrder.style.display = "none";

    var customerDetails = document.getElementById('customer');
    customerDetails.style.display = "block";
}

function Continue() {

    var Continue = document.getElementById('continue_btn');
    Continue.style.display = "none";

    var OrderTable = document.getElementById('Order');
    OrderTable.style.display = "block";
}

function GetCart() {
    if (sessionStorage.getItem("JwtToken") == null) {
        window.location.href = 'https://localhost:44309/User/Login';
    } else {
        $.ajax({
            type: "GET",
            url: 'https://localhost:44309/Cart/GetCart',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem("JwtToken")
            },
            dataType: "json",
            success: function () {
               
            },
            error: function () {
                alert("Error");
            }
        });
    }
}