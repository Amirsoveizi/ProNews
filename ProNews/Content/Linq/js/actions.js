$(document).ready(function () {
    function updateContainer(url) {
        $.ajax({
            url: url,
            type: 'GET',
            success: function (html) {
                $('#Container').html(html);
            },
            error: function () {
                alert("Failed to load names.");
            }
        });
    }

    $('#sort-desc').click(() => updateContainer('/Linq/SortDescending'));
    $('#show-names-s').click(() => updateContainer('/Linq/ShowNamesWithS'));
    $('#last-3-names').click(() => updateContainer('/Linq/Last3Names'));
    $('#first-last-names').click(() => updateContainer('/Linq/FirstAndLast'));
});