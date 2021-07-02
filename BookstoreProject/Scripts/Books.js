import { data } from "jquery";

function AddToCart(BookId) {

    var addtobag = "addtobag_btn-".concat(BookId);

    var data = {};
    data.UserId = 1;
    data.BookId = BookId;
    data.Quantity = 1;
    console.log(JSON.stringify(data));
    $.ajax({
        type: "POST",
        url: 'https://localhost:44309/Cart/AddToCart',
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            var AddTocartButton = document.getElementById(addtobag);
            AddTocartButton.style.display = "none";
        },
        error: function () {
            alert("error occured");
        }
    });
}