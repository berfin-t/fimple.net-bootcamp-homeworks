using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirector
    {
        
        public CreateDirectorModel Model { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public CreateDirector(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _movieStoreDbContext.Directors.SingleOrDefault(x => x.Name == Model.Name && x.LastName == Model.LastName);

            if (director != null)
                throw new InvalidOperationException("The director is already present.");

            director = _mapper.Map<Director>(Model);

            _movieStoreDbContext.Directors.Add(director);
            _movieStoreDbContext.SaveChanges();
        }

    }

    public class CreateDirectorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FilmsDirected { get; set; }

    }

}
