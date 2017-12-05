// coupon action start
$(document).ready(function () {
    var ids = [];
    $(".fa-coupon").each(function () {
        ids.push(this.dataset.bindId);
    });
    $("#" + ids.join(",#")).addClass("clicked");

    $(".table-td").click(addEvent);
    $(document).on("click", ".fa-coupon", removeEvent);
});

function addEvent() {
    $(this).toggleClass("clicked");
    $(this).siblings().removeClass("clicked");
    var id = $(this).attr("id");
    $.ajax({
        url: "/Bet/AddToCoupon",
        type: "POST",
        dataType: "html",
        contentType: "application/json",
        data: JSON.stringify({ id }),
        success: function (data) {
            $('.cupon-menu').html(data);
        }
    });

}

function removeEvent() {
    $("#" + $(this).attr("data-bind-id")).removeClass("clicked");
    var id = $(this).attr("id");
    console.log(id);
    $.ajax({
        url: "/Bet/RemoveFromCoupon",
        type: "POST",
        dataType: "html",
        contentType: "application/json",
        data: JSON.stringify({ id }),
        success: function (data) {
            $('.cupon-menu').html(data);
        }
    });
}
// coupon action end


//fixed header start

$(window).load(function () { headerFix() });
$(window).resize(function () { headerFix() });

function headerFix() {
    var headerHeight = $("#header").outerHeight() + "px";
    $("section").css({ "padding-top": headerHeight });
};
//fixed header end
