$(document).ready(function () {
    showAlertMessageAsDialog();

    $.vegas({
        src: 'http://egitim.immib.org.tr/jsv/istanbul_turu_1.jpg'
    });

    $('.flexslider').flexslider({
        animation: "slide",
        start: function (slider) {
            $('body').removeClass('loading');
        }
    });
});

var showAlertMessageAsDialog = function () {
    // serverside mesajları dialog olarak göstermek
    if ($("div.alert").length > 0) {
        $("div.alert").alert();
    }
};