$(document).ready(function () {
    var ids = [];
    $(".fa-coupon").each(function () {
        ids.push(this.dataset.bindId);
    });
    $("#" + ids.join(",#")).addClass("clicked");

    $(".table-td").click(addEvent);
    $(".fa-coupon").click(removeEvent);
});

function addEvent() {
    $(this).toggleClass("clicked");
    var id = $(this).attr("id");
    $.ajax({
        url: "/Bet/AddToCoupon",
        type: "POST",
        dataType: "html",
        contentType: "application/json",
        data: JSON.stringify({id}),
        success: function (data) {
            $('.cupon-menu').html(data);
        }
    });

}

function removeEvent() {
    var id = this.dataset.eventId;
    $.ajax({
        url: "/Bet/RemoveFromCoupon",
        type: "POST",
        dataType: "html",
        contentType: "application/json",
        data: JSON.stringify(id),
        success: function (data) {
            $('.cupon-menu').html(data);
        }
    });
}