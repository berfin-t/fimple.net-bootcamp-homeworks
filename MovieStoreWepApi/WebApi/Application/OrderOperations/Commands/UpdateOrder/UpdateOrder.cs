using AutoMapper;
using WebApi.Application.OrderOperations.Model;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrder
    {
        public UpdateOrderModel Model { get; set; }
        public int OrderId;


        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
       
       
        public UpdateOrder(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            Customer customer = _dbContext.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            Movie movies = _dbContext.Movies.SingleOrDefault(s => s.ID == Model.MovieId);
           
            Order order = _dbContext.Orders.SingleOrDefault(s => s.Id == OrderId);

            if (customer is null)
                throw new InvalidOperationException("Customer not found!");
            else if (movies is null)
                throw new InvalidOperationException("Movie not found!");
            else if (order is null)
                throw new InvalidOperationException("No data was found for the relevant record.");
                
            _mapper.Map<UpdateOrderModel, Order>(Model, order);

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }
    }

}