$(document).ready(function () {
    var selectedGenresIds = selectedMoviesIdsStr.split(' ');

    $('select[id=moviesDD]').val(selectedGenresIds);

    $('.selectpicker').selectpicker('refresh');
})