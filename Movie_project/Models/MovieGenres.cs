namespace Movie_project.Models
{
    public class MovieGenres
    {
        public int MovieId { get; set; }
        public Movie Movies { get; set; }

        public int GenresId { get; set; }
        public Genres Genres { get; set; }
    }
}