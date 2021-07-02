function AddToCart(BookId) {

    var addtobag = "addtobag_btn-".concat(BookId);

    var requestObject = {};
    requestObject.UserId = 1;
    requestObject.BookId = BookId;
    requestObject.Quantity = 1;
    console.log(JSON.stringify(requestObject));
    $.ajax({
        type: "POST",
        url: 'https://localhost:44309/Cart/AddToCart',
        data: JSON.stringify(requestObject),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            var AddTocartButton = document.getElementById(addtobag);
            AddTocartButton.style.display = "none";
        },
        error: function () {
            alert("error");
        }
    });
}