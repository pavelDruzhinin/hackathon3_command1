
$('#PassChange').on('click',
    function () {
        if ($('#OldPassword').val() === '' ||
            $('#NewPassword').val() === '' ||
            $('ConfirmNewPassword').val() === '') {
            return false;
        }
        if ($('#NewPassword').val() !== $('#ConfirmNewPassword').val()) {
            $('#errorMsg').show().fadeOut(5000);
            console.log('error 1');
            return false;
        }
        else {
            var data = $('#edit').serializeArray();
            var changePass = {
                OldPassword: data[0].value,
                NewPassword: data[1].value,
                ConfirmedNewPassword: data[2].value,
                };
            $.ajax(
                {
                    type: 'POST',
                    url: '/AccountChangePassword',
                    data: JSON.stringify(changePass),
                    contentType: 'application/json; charset=UTF-8',
                    success: function (response) {
                        console.log(response);
                        changePass.Id = response;
                        $('#edit').append('<p id="confirm" hidden><span style="color:green">Пароль изменен<p>');
                        $('#confirm').show().fadeOut(20000).done(function () { $('#confirm').detach(); });
                        $(':input:text').val();
                    },
                    error: function (response) {
                        console.log(response);
                    }
                });
        }
    });
