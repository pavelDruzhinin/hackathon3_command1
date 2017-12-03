$(document).ready(function () {
    $('#show').click(function () {
        var obj = {
            type: $("#bets").val(),
            results: $("#results").val()
        };
        $.ajax({
            type: 'POST',
            url: '/Account/CategorySearch',
            data: JSON.stringify(obj),
            contentType: 'application/json; charset=UTF-8',
            success: function (response) {
                $('#historyTable').html(response);
            }
        });
    });

});




