using WebApi.DbOprations;

namespace WebApi.Application.GenreOperations.Commands
{
    public class DeleteGenre
    {
        public int GenreID { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;

        public DeleteGenre(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;
        }

        public void Handle()
        {
            var genre = _movieStoreDbContext.Genres.SingleOrDefault(m => m.ID == GenreID);

            if (genre == null)
                throw new InvalidOperationException("Movie genre Not Found!");

            _movieStoreDbContext.Genres.Remove(genre);
            _movieStoreDbContext.SaveChanges();



        }

    }
}
