//site.js
(function startup() {
    // Provide expand collapse functionality for media events
    $("a[body-collapse]").click(function () {

        var href = $(this).attr('href');
        var seeMore = $(this).attr('data-see-more');
        var seeLess = $(this).attr('data-see-less');
        var elipses = $(this).attr('data-elipses');

        $(href).toggleClass("collapse");
        $(elipses).toggleClass("collapse");

        if ($(href).hasClass("collapse"))
            $(this).text(seeMore ? seeMore : '>>');
        else
            $(this).text(seeLess ? seeLess : '<<');
    }).each(function () {

        var href = $(this).attr('href');
        var seeMore = $(this).attr('data-see-more');
        var seeLess = $(this).attr('data-see-less');

        if ($(href).hasClass("collapse"))
            $(this).text(seeMore ? seeMore : '>>');
        else
            $(this).text(seeLess ? seeLess : '<<');
    });

})();

