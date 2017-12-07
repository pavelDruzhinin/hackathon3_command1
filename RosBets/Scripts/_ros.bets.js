﻿// coupon action start
$(document).ready(function () {
    var ids = [];
    $(".fa-coupon").each(function () {
        ids.push(this.dataset.bindId);
    });
    $("#" + ids.join(",#")).addClass("clicked");

    $(".table-td").click(addEvent);
    $(document).on("click", ".fa-coupon", removeEvent);
    $(document).on("click", ".submitExpress", createExpress);
    $(document).on("click", ".submitOrdinary", createOrdinary);
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

function createExpress() {
    var value = $("#expressBetValue").serialize();
    console.log(value);
    $.ajax({
        url: "/Bet/CreateBet",
        type: "POST",
        dataType: "html",
        data: value,
        success: function (data) {
            $('.cupon-menu').html(data);
        }
    });
}

function createOrdinary() {
    var eventId = $(this).attr("data-id");
    var values = $("#value_" + eventId).serialize() + "&couponEventId=" + eventId;
    console.log(values);
    $.ajax({
        url: "/Bet/CreateBet",
        type: "POST",
        dataType: "html",
        data: values,
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
