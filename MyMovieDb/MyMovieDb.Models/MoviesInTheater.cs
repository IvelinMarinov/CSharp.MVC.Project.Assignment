namespace MyMovieDb.Models
{
    public class MoviesInTheater
    {
        public int Id { get; set; }

        public Movie Movie { get; set; }

        public int MovieId { get; set; }

        public TheaterProgram TheaterProgram { get; set; }

        public int TheaterProgramId { get; set; }
    }
}
