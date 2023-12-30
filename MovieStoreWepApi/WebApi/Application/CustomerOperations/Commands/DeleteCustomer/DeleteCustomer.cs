using WebApi.DbOprations;

namespace WebApi.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomer
    {
        public int CustomerId { get; set; }

        private readonly IMovieStoreDbContext _movieStoreDbContext;


        public DeleteCustomer(IMovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;

        }
        public void Handle()
        {
            var customer = _movieStoreDbContext.Customers.SingleOrDefault(m => m.Id == CustomerId);

            if (customer == null)
                throw new InvalidOperationException("Customer Not Found!");

            _movieStoreDbContext.Customers.Remove(customer);
            _movieStoreDbContext.SaveChanges();



        }
    }
}
