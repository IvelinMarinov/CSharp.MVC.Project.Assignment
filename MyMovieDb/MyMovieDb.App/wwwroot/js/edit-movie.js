$(document).ready(function () {
    var selectedGenresIds = selectedGenresIdsStr.split(' ');
    var selectedActorsIds = selectedActorsIdsStr.split(' ');
    var selectedDirectorsIds = selectedDirectorsIdsStr.split(' ');
    var selectedProducersIds = selectedProducersIdsStr.split(' ');
    var selectedWritersIds = selectedWritersIdsStr.split(' ');

    $('select[id=genresDD]').val(selectedGenresIds);
    $('select[id=actorsDD]').val(selectedActorsIds);
    $('select[id=directorsDD]').val(selectedDirectorsIds);
    $('select[id=producersDD]').val(selectedProducersIds);
    $('select[id=writersDD]').val(selectedWritersIds);

    $('.selectpicker').selectpicker('refresh');
})