// coupon action start
$(document).ready(function () {
    addClicked();
    
    $(".table-td").click(addEvent);
    $(document).on("click", ".fa-coupon", removeEvent);
    $(document).on("click", ".fa-bigcross", clearCoupon);
    $(document).on("click", ".submitExpress", createExpress);
    $(document).on("click", ".submitOrdinary", createOrdinary);
    $(document).on("click", ".allOrdinary", allOrdinary);
    $(document).on("click", ".coupon-message", hideMessage);
    $(document).on("keyup", "#allOrdinary", copyToInputs);
    $(document).on("keyup", ".ord-input", renewOrdSummary);
    $(document).on("keyup", "#expressBetValue", renewExpSummary);
    renewOrdSummary();
    renewExpSummary();
    addMask();
});

function addMask() {
    Inputmask({ regex: "[0-9]+(\\.[0-9][0-9]?)?", placeholder:"" }).mask(".coupon-input");
}

function allOrdinary() {
    var allInputs = true;
    var values = [];
    $(".ord-input").each(function () {
        if ($(this).val()) {
            var obj = {
                eventId: $(this).attr("id").split("_").pop(),
                value: $(this).val()
            }
            values.push(obj);
        } else {
            allInputs = false;
            var id = $(this).attr("id").split("_").pop();
            $("div[data-msgid=" + id + "]").show();
        }
    });
    if(allInputs) {
    $.ajax({
        url: "/Bet/AllOrdinary",
        type: "POST",
        dataType: "html",
        contentType: "application/json",
        data: JSON.stringify(values),
        success: function (data) {
            if (data.result === "NotLoggedIn") {
                $(".login-error").show();
            } else if (data.result === "NoMoney") {
                $(".money-error").show();
            } else {
                $('.cupon-menu').html(data);
                $(".bet-success").show();
                clearClicked();
            }
        }
        });
    }

}

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
            addMask();
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

function clearCoupon() {
    $.ajax({
        url: "/Bet/ClearCoupon",
        type: "POST",
        dataType: "html",
        success: function (data) {
            $('.cupon-menu').html(data);
            clearClicked();
        }
    });
}

function createExpress() {
    var value = $("#expressBetValue").serialize();
    console.log(value);
    $.ajax({
        url: "/Bet/CreateBet",
        type: "POST",
      //  dataType: "html",
        data: value,
        success: function (data) {
            if (data.result === "NotLoggedIn") {
                $(".login-error").show();
            } else if (data.result === "NoMoney") {
                $(".money-error").show();
            } else {
                $('.cupon-menu').html(data);
                $(".bet-success").show();
                clearClicked();
            }
        }
    });
}

function createOrdinary() {
    var eventId = $(this).attr("data-id");
    if ($("#value_" + eventId).val()) {
        var values = $("#value_" + eventId).serialize() + "&couponEventId=" + eventId;
        $.ajax({
            url: "/Bet/CreateBet",
            type: "POST",
            //      dataType: "html",
            data: values,
            success: function(data) {
                if (data.result === "NotLoggedIn") {
                    $(".login-error").show();
                } else if (data.result === "NoMoney") {
                    $(".money-error").show();
                } else {
                    $('.cupon-menu').html(data);
                    $(".bet-success").show();
                    clearClicked();
                    addClicked();
                    addMask();
                }
            }
        });
    } else {
        $("div[data-msgid=" + eventId + "]").show();
    }
}

function addClicked() {
    var ids = [];
    $(".fa-coupon").each(function() {
        ids.push(this.dataset.bindId);
    });
    $("#" + ids.join(",#")).addClass("clicked");
}

function clearClicked() {
    $("td").removeClass("clicked");
}

function hideMessage() {
    $(this).hide();
}

function copyToInputs() {
    $(".ord-input").val($(this).val());
    renewOrdSummary();
}

function renewOrdSummary() {
    var sum = 0;
    $(".ord-input").each(function() {
        sum += Number($(this).val());
    });
    if (sum) {
        $("#ordinary-sum").text(sum);
        var coeff = $("#ord-total-coeff").text().replace(",", ".");
        console.log(coeff);
        $("#ordinary-payout").text((sum * coeff).toFixed(2));
        $(".ordinary-summary").show();
    } else {
        $(".ordinary-summary").hide();
    }
}

function renewExpSummary() {
    if ($("#expressBetValue").val()) {
        $("#express-sum").text(($("#expressBetValue").val() * $("#exp-total-coeff").text().replace(",", ".")).toFixed(2));
        $(".express-summary").show();
    } else {
        $(".express-summary").hide();
    }
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

//admin section start
$(document).ready(function () {
    var $rows = $('#client-table tr');
    $('#seach-input').keyup(function () {
        var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

        $rows.show().filter(function () {
            var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
            return !~text.indexOf(val);
        }).hide();
    });
});
//admin section end