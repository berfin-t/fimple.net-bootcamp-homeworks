using WebApi.DbOprations;

namespace WebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirector
    {
        public int DirectorId { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;


        public DeleteDirector(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;

        }
        public void Handle()
        {
            var director = _movieStoreDbContext.Directors.SingleOrDefault(m => m.Id == DirectorId);

            if (director == null)
                throw new InvalidOperationException("Director Not Found!");

            _movieStoreDbContext.Directors.Remove(director);
            _movieStoreDbContext.SaveChanges();



        }
    }
}