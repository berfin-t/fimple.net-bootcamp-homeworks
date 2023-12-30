using WebApi.DbOprations;

namespace WebApi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActor
    {

        public int ActorId { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;


        public DeleteActor(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;

        }
        public void Handle()
        {
            var actor = _movieStoreDbContext.Actors.SingleOrDefault(m => m.Id == ActorId);

            if (actor == null)
                throw new InvalidOperationException("No Player Found!");

            _movieStoreDbContext.Actors.Remove(actor);
            _movieStoreDbContext.SaveChanges();



        }
    }
}