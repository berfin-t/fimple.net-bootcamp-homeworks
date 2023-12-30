using WebApi.DbOprations;

namespace WebApi.Application.OrderOperations.Commands.DeleteOrder
{
    public class SoftDeleteOrder
    {
        public int OrderId;


        private readonly IMovieStoreDbContext _dbContext;

        public SoftDeleteOrder(IMovieStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle()
        {
            var order = _dbContext.Orders.SingleOrDefault(s => s.Id == OrderId);

            if (order is null)
                throw new InvalidOperationException("No data was found for the relevant record!");

            order.IsActive = false;

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }
    }
}