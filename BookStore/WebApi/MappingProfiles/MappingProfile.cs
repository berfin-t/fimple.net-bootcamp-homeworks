using AutoMapper;
using WebApi.Entities;
using WebApi.Operations.AuthorOperations.Create.Commands;
using WebApi.Operations.AuthorOperations.Queries;
using WebApi.Operations.AuthorOperations.Update.Commands;
using WebApi.Operations.BookOperations.Create.Commands;
using WebApi.Operations.BookOperations.Queries;
using WebApi.Operations.BookOperations.Update.Commands;
using WebApi.Operations.GenreOperations.Create.Commands;
using WebApi.Operations.GenreOperations.Queries;
using WebApi.Operations.GenreOperations.Update.Commands;
using WebApi.Operations.UserOperations.Create.Commands;

namespace WebApi.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserModel, User>();
            CreateMap<CreateTokenModel, User>();
            CreateMap<CreateBookModel, Book>();
            CreateMap<UpdateBookModel, Book>();
            CreateMap<Book, BooksViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(
                    dest => dest.PublishDate,
                    opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyyy"))
                );
            CreateMap<Book, BookDetailViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(
                    dest => dest.PublishDate,
                    opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyyy"))
                );


            CreateMap<CreateGenreModel, Genre>();
            CreateMap<UpdateGenreModel, Genre>();
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<CreateAuthorModel, Author>();
            CreateMap<UpdateAuthorModel, Author>();
            CreateMap<Author, AuthorsViewModel>()
                .ForMember(
                    dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => src.DateOfBirth.Date.ToString("dd/MM/yyyy"))
                );
            CreateMap<Author, AuthorDetailViewModel>()
                .ForMember(
                    dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => src.DateOfBirth.Date.ToString("dd/MM/yyyy"))
                );

            CreateMap<AddBookToAuthorModel, Book>();
            CreateMap<AddAuthorToBookModel, Author>();
        }
    }
}
