//contact.js
(function startup() {
    $('form input[type=submit]').tooltip();
    $('form input[type=submit]').prev().tooltip();
    $('a:contains("Home")').filter(function (index) {
        return $(this).text() === "Home";
    }).tooltip();
})();

