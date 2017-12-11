$(document).ready(function () {
    $('#show').click(function () {
        var obj = {
            sport: $("#sport").val(),
            date: $("#date").val()
        };
        $.ajax({
            type: 'POST',
            url: '/Results/MyShowResults',
            data: JSON.stringify(obj),
            contentType: 'application/json; charset=UTF-8',
            //success: function (response) {
            //    $('#result-story').html(response);
            //},
            //error: function (response) {
            //    console.log(response);
            //}
        });
    });

});