(document).ready(function () {
    $('#show').click(function () {
        var obj = {
            date: $("#date").val(),
            sport: $("#sport").val()
        };
        $.ajax({
            type: 'POST',
            url: '/Results/MyShowResults',
            data: JSON.stringify(obj),
            contentType: 'application/json; charset=UTF-8',
            success: function (response) {
                /*console.log(response);                
                var newHtml = response.map(function (el) {
                    return createPr(el);
                }).join("");*/
                $('#result-story').html(response);
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

});