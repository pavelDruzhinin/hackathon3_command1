        $(document).ready(function () {
            $('#show').click(function () {
                var obj = {
                    //var type = $("#bets").val(),
                    //var results = $("results").val()
                    type: $("#bets").val(),
                    results: $("#results").val()
                };
                $.ajax({
                    type: 'POST',
                    url: '/Account/CategorySearch',
                    data: JSON.stringify(obj),
                    //data: type, result,
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



            function createPr(bet) {
                return '<tr><th>' +
                    bet.MatchName + '</th><th>' + bet.Success + '</th><th>' + bet.TotalCoefficient + '</th><td>' +
                    '</th><th>' + bet.Success + '</th></tr>';
            }


