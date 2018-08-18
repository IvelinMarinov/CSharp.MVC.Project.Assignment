$(document).ready(function () {
    console.log('in')
    var deleteBtns = $('[id^=deleteBtn]');
    var itemId;
    var itemDescription;
    var itemType;

    $(deleteBtns).click(function () {
        itemId = $(this).attr('id').split('-')[1];
        itemDescription = $(this).parent().parent().children()[0].textContent;
        var currentUrlTokens = window.location.href.split('/');
        itemType = currentUrlTokens[currentUrlTokens.length - 2];

        $('#deleteModal').modal('show');
        $('#deleteModalCloseBtn').modal('hide');
    });

    $('#deleteModal').on('shown.bs.modal', function () {
        var action = '/Moderator/' + itemType + '/Delete/' + itemId;
        var modalContent = 'Are you sure you want to delete ' + itemDescription;

        $('#modalContent').text(modalContent);
        $('#deleteModal form').attr('action', action);
    });
});