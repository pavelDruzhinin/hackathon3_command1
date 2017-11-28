        $(document).ready(function () {
            $('#show').click(function () {
                var obj = {
                    searchName: $(this).val(),
                    //searchSurname: $(this).val('#results')
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



            function createPr(bet) {
                return '<tr><th>' +
                    bet.MatchName + '</th><th>' + bet.Success + '</th><th>' + bet.TotalCoefficient + '</th><td>' +
                    '</th><th>' + bet.Success + '</th></tr>';
            }


