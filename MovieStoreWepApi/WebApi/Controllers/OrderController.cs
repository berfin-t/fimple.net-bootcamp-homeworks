using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.Application.OrderOperations.Commands.DeleteOrder;
using WebApi.Application.OrderOperations.Commands.UpdateOrder;
using WebApi.Application.OrderOperations.Model;
using WebApi.Application.OrderOperations.Queries.GetByIdOrder;
using WebApi.Application.OrderOperations.Queries.GetListOrder;
using WebApi.DbOprations;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetLists()
        {
            GetListOrder query = new GetListOrder(_dbContext, _mapper);
            var response = query.Handle();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            GetByIdOrder query = new GetByIdOrder(_dbContext, _mapper);
            query.OrderId = id;

            
            var response = query.Handle();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderModel model)
        {
            CreateOrder command = new CreateOrder(_dbContext, _mapper);
            command.Model = model;          
            command.Handle();

            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update([FromBody] UpdateOrderModel model, int Id)
        {
            UpdateOrder command = new UpdateOrder(_dbContext, _mapper);
            command.Model = model;
            command.OrderId = Id;
            
            command.Handle();

            return Ok();
        }

        [HttpPut("softDelete/{Id}")]
        public IActionResult SoftDelete([FromRoute] int Id)
        {
            SoftDeleteOrder command = new SoftDeleteOrder(_dbContext);

            command.OrderId = Id;
            command.Handle();

            return Ok();
        }
    }
}
