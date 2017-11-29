$(document).ready(function () {

    $(".table-td").click(function () {
        $(this).toggleClass("clicked");
        var ids = [];
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
            }
        });

    });

});