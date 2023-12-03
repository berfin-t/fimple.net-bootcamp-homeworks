using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HomeworkUsingModels.DBOperations;
using HomeworkUsingModels.Operations.UserOperations.Commands.Create;
using HomeworkUsingModels.Operations.UserOperations.Create.Commands;
using HomeworkUsingModels.TokenOperations.Models;

namespace HomeworkUsingModels.Controllers
{
    public class UserController : Controller
    {
        [ApiController]
        [Route("[controller]")]
        public class UsersController : ControllerBase
        {
            readonly IBookStoreDbContext _context;
            readonly IMapper _mapper;
            readonly IConfiguration _config;

            public UsersController(IBookStoreDbContext context, IMapper mapper, IConfiguration config)
            {
                _context = context;
                _mapper = mapper;
                _config = config;
            }

            [HttpPost]
            public IActionResult Create([FromBody] CreateUserModel newUser)
            {
                CreateUserCommand command = new CreateUserCommand(_context, _mapper, newUser);
                command.Handle();

                return Ok();
            }

            [HttpPost]
            [Route("login")]
            public ActionResult<Token> CreateToken([FromBody] CreateTokenModel loginModel)
            {
                CreateTokenCommand command = new CreateTokenCommand(
                    _context,
                    _mapper,
                    _config,
                    loginModel
                );
                var token = command.Handle();

                return Ok(token);
            }

            [HttpGet]
            [Route("refreshToken")]
            public ActionResult<Token> RefreshToken([FromQuery] string token)
            {
                RefreshTokenCommand command = new RefreshTokenCommand(_context, _config, token);
                var result = command.Handle();

                return Ok(result);
            }
        }
    }
}
