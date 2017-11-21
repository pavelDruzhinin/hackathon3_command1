function proverka(input) {
    var value = input.value;
    var rep = /[-\.;":'a-zA-Zа-яА-Я]/;
    if (rep.test(value)) {
        value = value.replace(rep, '');
        input.value = value;
    }
}

$('#Register').on('click',
    function () {
        if ($('#FirstName').val() === '' ||
            $('#LastName').val() === '' ||
            $('#MiddleName').val() === '' ||
            $('#Mail').val === '' ||
            $('#Phone').val() === '' ||
            $('#City').val() === '') {
            return false;
        }
        if ($('#Password').val() !== $('#RePass').val()) {
            $('#errorMsg').show().fadeOut(5000);
            console.log('error 1');
            return false;
        }
        else {
            var data = $('#edit').serializeArray();
            var user = {
                FirstName: data[0].value,
                LastName: data[1].value,
                MiddleName: data[2].value,
                Mail: data[3].value,
                Phone: data[4].value,
                City: data[5].value,
                Password: data[6].value
            };
            $.ajax(
                {
                    type: 'POST',
                    url: '/Home/Register',
                    data: JSON.stringify(user),
                    contentType: 'application/json; charset=UTF-8',
                    success: function (response) {
                        console.log(response);
                        user.Id = response;
                        $('#edit').append('<p id="confirm" hidden><span style="color:green">Регистрация прошла успешно<p>');
                        $('#confirm').show().fadeOut(20000).done(function () { $('#confirm').detach(); });
                        $(':input:text').val();
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
        }
    });
$('#edt input').focus(function() {
    if ($('#FirstName').val() === '') {
        $('#errorMsg2').show();
        console.log('error 1');
    } else {
        $('#errorMsg2').hide();
    }

    if ($('#LastName').val() === '') {
        $('#errorMsg3').show();
        console.log('error 1');
    } else {
        $('#errorMsg3').hide();
    }

    if ($('#MiddleName').val() === '') {
        $('#errorMsg4').show();
        console.log('error 1');
    } else {
        $('#errorMsg4').hide();
    }

    if ($('#Mail').val() === '') {
        $('#errorMsg5').show();
        console.log('error 1');
    } else {
        $('#errorMsg5').hide();
    }

    if ($('#Phone').val() === '') {
        $('#errorMsg6').show();
        console.log('error 1');
    } else {
        $('#errorMsg6').hide();
    }

    if ($('#City').val() === '') {
        $('#errorMsg7').show();
        console.log('error 1');
    } else {
        $('#errorMsg7').hide();
    }
});
