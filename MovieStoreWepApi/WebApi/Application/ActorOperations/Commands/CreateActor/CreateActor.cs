using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActor
    {


        public CreateActorModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public CreateActor(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _movieStoreDbContext.Actors.SingleOrDefault(x => x.Name == Model.Name && x.LastName == Model.LastName);

            if (actor != null)
                throw new InvalidOperationException("The player already exists.");

            actor = _mapper.Map<Actor>(Model);

            _movieStoreDbContext.Actors.Add(actor);
            _movieStoreDbContext.SaveChanges();
        }

    }

    public class CreateActorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PlayedMovies { get; set; }
    }

}
