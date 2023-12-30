using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands;
using WebApi.Application.GenreOperations.Querys;
using WebApi.Application.GenreOperations.Validator;
using WebApi.DbOprations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetListGenres()
        {
            GetListGenre query = new GetListGenre(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetByIdGenre(int id)
        {
            GenreDetailModel result;

            GetByIdGenre query = new GetByIdGenre(_context, _mapper);
            query.GenreId = id;

            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateGenreModel model)
        {
            CreateGenre command = new CreateGenre(_context, _mapper);
            command.Model = model;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            DeleteGenre command = new DeleteGenre(_context);
            command.GenreID = id;
            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateGenreModel model)
        {
            UpdateGenre command = new UpdateGenre(_context, _mapper);

            command.GenreID = id;

            command.Model = model;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

    }
}
