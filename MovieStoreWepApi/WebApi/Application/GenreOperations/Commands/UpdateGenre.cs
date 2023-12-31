﻿using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands
{
    public class UpdateGenre
    {

        public UpdateGenreModel Model { get; set; }
        public int GenreID { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;
        private readonly IMapper _mapper;

        public UpdateGenre(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _movieStoreDbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _movieStoreDbContext.Genres.SingleOrDefault(x => x.ID == GenreID);

            if (genre == null)
            {
                throw new InvalidOperationException("Movie genre Not Found!");
            }


            _mapper.Map<UpdateGenreModel, Genre>(Model, genre);

            _movieStoreDbContext.Genres.Update(genre);
            _movieStoreDbContext.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
