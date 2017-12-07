﻿$(document).ready(function () {
    var ids = [];
    $(".table-td").click(postCoupon);
              
});

function postCoupon() {  
    $(this).toggleClass("clicked")
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
            $(".fa-coupon").click(deleteCoupon);
        }
    });

} 

function deleteCoupon() {
    console.log(this.dataset.bindId);
    $("#" + this.dataset.bindId).toggleClass("clicked");
    postCoupon();
}