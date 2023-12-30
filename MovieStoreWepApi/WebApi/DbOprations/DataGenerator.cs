using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOprations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Directors.AddRange(
          new Director { Name = "Deneme1", LastName = "Deneme2", FilmsDirected = "Deneme3", IsActive = true },
          new Director { Name = "Deneme4", LastName = "Deneme5", FilmsDirected = "Deneme6", IsActive = true }
          );
                context.SaveChanges();

                context.Actors.AddRange(
                  new Actor { Name = "Deneme7", LastName = "Deneme8", PlayedMovies = "Deneme9", IsAvtive = true },
                  new Actor { Name = "Deneme10", LastName = "Deneme11", PlayedMovies = "Deneme12", IsAvtive = true }
                  );
                context.SaveChanges();

                context.Movies.AddRange(

                    new Movie
                    {
                        GenreID = 1,
                        Title = "Deneme13",
                        Year = "2015",
                        Director = "Deneme1",
                        Actors = "Deneme7, Deneme10",
                        Price = 60,
                        IsActive = true

                    },

                    new Movie
                    {
                        GenreID = 2,
                        Title = "Deneme14",
                        Year = "2021",
                        Director = "Deneme4",
                        Actors = " Deneme7",
                        Price = 55,
                        IsActive = true

                    }
                    );

                context.Genres.AddRange(
                   new Genre
                   {
                       Name = "Action "
                   },
                   new Genre
                   {
                       Name = "Animation"
                   }
               );
                context.SaveChanges();

                context.Customers.AddRange(
         new Customer
         {
             Name = "Berfin",
             LastName = "Tek",
             Email = "berfin@mail.com",
             Password = "123456",
             IsActive = true           

         });

                context.SaveChanges();

                context.Orders.AddRange(
                  new Order { CustomerId = 1 , MovieId = 1, purchasedTime = new DateTime(2023, 12, 30) , IsActive = true }
                  );

                context.SaveChanges();
            }
        }

    }
}
