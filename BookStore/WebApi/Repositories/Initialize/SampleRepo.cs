using WebApi.Entities;

namespace WebApi.Repositories.Initialize
{
    public static class SampleRepo
    {
        public static List<Genre> Genres
        {
            get
            {
                var genres = new List<Genre>
                {
                    new Genre { Name = "Personal Growth" },
                    new Genre { Name = "Romance" },
                    new Genre { Name = "Adventure" },
                };
                return genres;
            }
        }

        public static List<Book> Books
        {
            get
            {
                var books = new List<Book>
                {
                    new Book
                    {
                        GenreId = 1,
                        Title = "Deneme40",
                        PageCount = 503,
                        PublishDate = DateTime.Parse("2020-05-08")
                    },
                    new Book
                    {
                        GenreId = 2,
                        Title = "Deneme41",
                        PageCount = 120,
                        PublishDate = DateTime.Parse("2020-05-08")
                    }
                };
                return books;
            }
        }

        public static List<Author> Authors
        {
            get
            {
                var authors = new List<Author>
                {
                    new Author
                    {
                        FirstName = "Berfin",
                        LastName = "Tek",
                        DateOfBirth = DateTime.Parse("1999-10-25")
                    }
                };
                return authors;
            }
        }
    }
}
