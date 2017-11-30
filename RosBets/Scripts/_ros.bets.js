$(document).ready(function () {
    var ids = [];
    $(".table-td").click(toggleClick);
              
});
function toggleClick() {
    $(this).toggleClass("clicked");
    postCoupon();
}

function postCoupon() {   
    ids = [];
    $(".clicked").each(function () {
        ids.push(this.id);
    });

    $.ajax({
        url: "/Bet/GetCoupon",
        type: "POST",
        dataType: "html",
        contentType: "application/json",
        data: JSON.stringify(ids),
        success: function (data) {
            $('.cupon-menu').html(data);
            console.log(JSON.stringify(ids));
            $(".fa-coupon").click(toggleTd);
        }
    });

} 

function toggleTd() {
    console.log(this.dataset.bindId);
    $("#" + this.dataset.bindId).toggleClass("clicked");
    postCoupon();
}