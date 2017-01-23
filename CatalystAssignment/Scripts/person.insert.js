$(document).ready(function () {

    $body = $('body');

    $(document).on({
        ajaxStart: function () { $body.addClass("loading"); },
        ajaxStop: function () { $body.removeClass("loading"); }
    });


    $('#insertPerson').submit(function (e) {

        var input, files;

        var form = $('form')[0];
        var formData = new FormData(form);
        //Now insert Pic!
        input = document.getElementById('pictureFile');
        files = input.files;

        if (window.FormData !== undefined) {
            var newPerson = JSON.stringify({
                'FirstName': $('#firstName').val(),
                'LastName': $('#lastName').val(),
                'Address1': $('#address1').val(),
                'Address2': $('#address2').val(),
                'City': $('#city').val(),
                'State': $('#state').val(),
                'Zipcode': $('#zipcode').val(),
                'Intrests': $('#intrests').val()
            });

            formData.append("newPerson", newPerson);
            if (files.length > 0) {
                formData.append("picture", files[0]);
            }
            

            $.ajax(
            {
                url: '/Person/InsertPerson',
                type: 'POST',
                data: formData,
                contentType: false,
                processData: false,
                success: function () {
                    clearForm();
                }
            });
        }
        else {
            clearForm();
        }

        e.preventDefault();

    });

    function clearForm() {
        $('#insertPerson')[0].reset();
    }


});