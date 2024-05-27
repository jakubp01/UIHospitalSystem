$(document).ready(function () {
    var searchInput = $("#searchInput");
    var searchLabel = $("#searchLabel");

    searchInput.on("input", function () {
        var value = $(this).val().toLowerCase();
        $(".rowElements").each(function () {
            var rowText = $(this).text().toLowerCase();
            $(this).toggle(rowText.includes(value));
        });

        // Toggle label visibility
        searchLabel.toggleClass("hidden", value.length > 0);
    });
});