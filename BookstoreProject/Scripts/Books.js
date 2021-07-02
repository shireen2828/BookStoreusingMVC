import { data } from "jquery";

function AddToCart(BookId) {

    var addtobag = "addtobag_btn-".concat(BookId);
    var addtowishlist = "wishlist_btn-".concat(BookId);
    var addedtobag = "addedtobag_btn-".concat(BookId);

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
            var AddTocartBtn = document.getElementById(addtobag);
            AddTocartBtn.style.display = "none";

            var AddToWishlistBtn = document.getElementById(addtowishlist);
            AddToWishlistBtn.style.display = "none";

            var AddedToCartButton = document.getElementById(addedtobag);
            AddedToCartButton.style.display = "block"

        },
        error: function () {
            alert("error occured");
        }
    });
}