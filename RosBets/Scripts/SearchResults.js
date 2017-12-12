    $(document).ready(function () {
        $('#botShow').click(function () {
            var obj = {
                sport: $("#sport").val(),
                date1: $("#date1").val(),
                date2: $("#date2").val(),
            };
            $.ajax({
                type: 'POST',
                url: '/Results/MyShowResults',
                data: JSON.stringify(obj),
                contentType: 'application/json; charset=UTF-8',
                success: function (response) {
                    $('#result-story').html(response);
                },
                error: function (response) {
                    console.log(response);
                }
            });
        });

    });