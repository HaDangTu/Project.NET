
$("document").ready(function () {
    var url = window.location.pathname;

    $(".active").removeClass("active");
    $(".nav-link").each(function (index, element) {
        var link = $(element);
        if (link.attr("href") == url) {
            link.addClass("active");
        }
    });
});