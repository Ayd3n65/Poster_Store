using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PosterStore.Data;
using PosterStore.Dtos;

namespace PosterStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
         private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var isCurrentUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == id;
            
            var user = await _repo.GetUser(id, isCurrentUser);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }
        // [HttpGet]
        // public async Task<IActionResult> GetUsers()
        // {
        //     var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        //     var userFromRepo = await _repo.GetUser(currentUserId, true);

        //     userParams.UserId = currentUserId;

        //     var users = await _repo.GetUsers();

        //     var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

        //     return Ok(usersToReturn);
        // }
    }

}