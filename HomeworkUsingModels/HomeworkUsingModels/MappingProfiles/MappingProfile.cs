using AutoMapper;
using HomeworkUsingModels.Entities;
using HomeworkUsingModels.Operations.AuthorOperations.Create.Commands;
using HomeworkUsingModels.Operations.AuthorOperations.Queries;
using HomeworkUsingModels.Operations.AuthorOperations.Update.Commands;
using HomeworkUsingModels.Operations.BookOperations.Create.Commands;
using HomeworkUsingModels.Operations.BookOperations.Queries;
using HomeworkUsingModels.Operations.BookOperations.Update.Commands;
using HomeworkUsingModels.Operations.GenreOperations.Create.Commands;
using HomeworkUsingModels.Operations.GenreOperations.Queries;
using HomeworkUsingModels.Operations.GenreOperations.Update.Commands;
using HomeworkUsingModels.Operations.UserOperations.Create.Commands;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeworkUsingModels.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mapping
            CreateMap<CreateUserModel, User>();
            CreateMap<CreateTokenModel, User>();

            // Book Mapping
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

            // Genre mapping
            CreateMap<CreateGenreModel, Genre>();
            CreateMap<UpdateGenreModel, Genre>();
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

            // Author mapping
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

            // Add book to author mapping
            CreateMap<AddBookToAuthorModel, Book>();
            // Add author to book mapping
            CreateMap<AddAuthorToBookModel, Author>();
        }
    }
}
