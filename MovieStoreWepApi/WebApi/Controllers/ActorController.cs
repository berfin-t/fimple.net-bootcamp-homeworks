using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Commands.DeleteActor;
using WebApi.Application.ActorOperations.Querys.GetListActor;
using WebApi.DbOprations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;     

        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;           
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateActorModel createActor)
        {
            CreateActor command = new CreateActor(_context, _mapper);
            command.Model = createActor;
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            DeleteActor command = new DeleteActor(_context);
            command.ActorId = id;

            command.Handle();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            GetListActor query = new GetListActor(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

    }
}
