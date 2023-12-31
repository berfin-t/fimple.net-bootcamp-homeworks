﻿using AutoMapper;
using WebApi.Application.OrderOperations.Model;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrder
    {
        public CreateOrderModel Model;

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public CreateOrder(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            var movies = _dbContext.Movies.SingleOrDefault(s => s.ID == Model.MovieId);

            if (customer is null)
                throw new InvalidOperationException("Customer not found!");
            if (movies is null)
                throw new InvalidOperationException("Movie not found!");
           

            var result = _mapper.Map<Order>(Model);
            result.purchasedTime = DateTime.Now;
            result.IsActive = true;

            _dbContext.Orders.Add(result);
            _dbContext.SaveChanges();
        }
    }


}