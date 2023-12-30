using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieOperations.Commands;
using WebApi.Application.MovieOperations.Querys;
using WebApi.Application.MovieOperations.Validator;
using WebApi.DbOprations;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetListMovies()
        {
            GetListMovie query = new GetListMovie(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MovieDetailModel result;

            GetByIdMovie query = new GetByIdMovie(_context, _mapper);
            query.Id = id;
            
            result = query.Handle();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateMovieModel model) 
        {
            CreateMovie command = new CreateMovie(_context, _mapper);
            command.Model = model;

            CreateMovieValidator validator = new CreateMovieValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) 
        {
            DeleteMovie command = new DeleteMovie(_context);
            command.Id = id;

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateMoveiModel model) 
        {
            UpdateMovie command = new UpdateMovie(_context, _mapper);

            command.MovieId = id;
            
            command.Model = model;
            
            UpdateMovieValidator validator = new UpdateMovieValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

    }
}
