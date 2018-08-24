$(document).ready(function () {
    var movieTitle;
    var movieId;
    var modalContent;
    var voteValue;

    $('#rateMovieBtn').click(function () {

        movieTitle = $('#movieTitle').text();
        movieId = $('#movieId').val();

        $('#rateMovieModal').modal('show');
        $('#closeBtn').modal('hide');
    });

    //Check if user already rated movie
    $('#rateMovieModal').on('show.bs.modal', function () {
        $.ajax({
            url: "/movies/CheckIfUserAlreadyVotedForMovie",
            method: "GET",
            data: {
                movieId: movieId,
                userId: userId
            },
            success: function(result) {
                //No vote exists
                if (Number(result) === -1) {
                    modalContent = "Your rating for '" + movieTitle + "'";
                //Vote exists -> add value in modal
                } else {
                    modalContent = "You have already rated '" + movieTitle + "', change rating?";
                    voteValue = Number(result);
                    $('#star' + voteValue).attr('checked', 'checked');
                }

                $('#modalContent').text(modalContent);
            }
        });
    });


    $('#rateMovieModal').on('shown.bs.modal', function () {
        $('#userToRateId').val(userId);
        $('#movieToRateId').val(movieId);
        $('#movieTitleToRate').text(movieTitle);
    });
});

