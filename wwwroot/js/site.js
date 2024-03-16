$( document ).ready(function() {
    $('#sendRequest').click(function () {

        var inputValue = $('#inputField').val();

        $.ajax({
            url: '/home/ProcessRequest',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(inputValue),
            success: function (response) {
                $("#llama-response").empty();
                $("#llama-response").append("<p>" + response + "</p>");
            },
            error: function (xhr, status, error) {
                console.error('Error: ' + error); // Log the error
            }
        });
    });
});