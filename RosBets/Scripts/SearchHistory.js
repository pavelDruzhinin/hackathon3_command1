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
                console.log(response);                
                var newHtml = response.map(function (el) {
                    return createPr(el);
                }).join("");
                $('#ourtable tbody').html(newHtml);                
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

});



function createPr(bet)
{
    var tempSuccess;
    if (bet.Success === true) { tempSuccess = 'выигрыш'; }
    else if (bet.Success === false) { tempSuccess = 'проигрыш'; }
    else { tempSuccess = 'не определено'; }

    return '<tr><td rowspan="1">' +
        bet.MatchName + '</td><td rowspan="1">' + bet.MyDate + '</td><td rowspan="1">' + tempSuccess + 
        '</td><td rowspan="1">' + bet.Shortname + '</td><td>' + bet.TotalCoefficient +  '</td></tr>';
}

