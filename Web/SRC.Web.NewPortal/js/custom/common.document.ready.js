$(document).ready(function () {
    showAlertMessageAsDialog();

    $("input[inputtype='phonenumber']").mask("999-9999999");

    $.vegas({
        src: baseUrl + 'img/istanbul_turu_1.jpg'
    });

    $('.flexslider').flexslider({
        animation: "slide",
        start: function (slider) {
            $('body').removeClass('loading');
        }
    });

    $("a[type='loginbutton']").click(function () {
        $('#login').modal();
    });

    $("a[type='exitbutton']").click(function () {

        var exitDataUrl = baseUrl + 'api/contactapi/ExitProfile';

        $.ajax({
            url: exitDataUrl,
            type: 'POST',
            data: {
            }
        }).success(function (data) {
            if (data && data.Success && data.Result) {

                window.document.location = baseUrl;
            }
            else {
                alertModal(data.Message, "error");
            }
        });
    });
});

var showAlertMessageAsDialog = function () {
    // serverside mesajları dialog olarak göstermek
    if ($("div.alert").length > 0) {
        $("div.alert").alert();
    }
};