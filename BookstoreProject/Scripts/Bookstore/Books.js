function AddToCart(BookId) {

    var addtobagId = "addtobag_btn-".concat(BookId);
    var addtowishlistId = "wishlist_btn-".concat(BookId);
    var addedtobag = "addedtobag_btn-".concat(BookId); 

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
            var AddTocartButton = document.getElementById(addtobagId);
            AddTocartButton.style.display = "none";

            var AddToWishlistBtn = document.getElementById(addtowishlistId);
            AddToWishlistBtn.style.display = "none";

            var Added = document.getElementById(addedtobag);
            Added.style.display = "block";
        },
        error: function () {
            alert("error");
        }
    });
}

function AddToWishlist(BookId) {
    var addtobagId = "addtobag_btn-".concat(BookId);
    var addtowishlistId = "wishlist_btn-".concat(BookId);
    var addedtowishlist = "addedtowishlist_btn-".concat(BookId); 

    var requestObject = {};
    requestObject.UserId = 1;
    requestObject.BookId = BookId;
    requestObject.Quantity = 1;
    console.log(JSON.stringify(requestObject));
    $.ajax({
        type: "POST",
        url: 'https://localhost:44309/Wishlist/AddToWishlist',
        data: JSON.stringify(requestObject),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            var AddTocartButton = document.getElementById(addtobagId);
            AddTocartButton.style.display = "none";

            var AddToWishlistBtn = document.getElementById(addtowishlistId);
            AddToWishlistBtn.style.display = "none";

            var Addedwish = document.getElementById(addedtowishlist);
            Addedwish.style.display = "block";
        },
        error: function () {
            alert("error occured");
        }
    });
}