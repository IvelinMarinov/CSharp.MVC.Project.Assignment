$(document).ready(function () {
    var selectedGenresIds = selectedGenresIdsStr.split(' ');

    $('select[id=moviesDD]').val(selectedGenresIds);

    $('.selectpicker').selectpicker('refresh');
})