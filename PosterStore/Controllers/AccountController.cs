using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PosterStore.Data;
using PosterStore.Dtos;
using PosterStore.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace PosterStore.Controllers
{
  [AllowAnonymous]
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly IAuthRepository _repo;
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public AccountController(IConfiguration config, UserManager<User> userManager,
      SignInManager<User> signInManager, IMapper mapper)
    {
      _mapper = mapper;
      _config = config;
      _userManager = userManager;
      _signInManager = signInManager;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
    {
      // валидация 
      // userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            var userToCreate = _mapper.Map<User>(userForRegisterDto);

            var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);

            var userToReturn = _mapper.Map<UserForDetailedDto>(userToCreate);

            if (result.Succeeded)
            {
                return CreatedAtRoute("GetUser", 
                    new { controller = "Users", id = userToCreate.Id }, userToReturn);
            }

            return BadRequest(result.Errors);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {
            var user = await _userManager.FindByNameAsync(userForLoginDto.Username);
            var result = await _signInManager
                .CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.NormalizedUserName == userForLoginDto.Username.ToUpper());

                var userToReturn = _mapper.Map<UserForListDto>(appUser);

                return Ok(new
                {
                    token = GenerateJWtToken(appUser).Result,
                    user = userToReturn
                });
            }

            return Unauthorized();
      // Создаем токен который потом отправим юзеру, он будет содержать 2-битную инф о юзере(username и password) 
      //Так как токен валидирован сервером без использования бд,сервер сможет заглянуть внутрь токена и получит данные о юзере

    }
    private async Task<string> GenerateJWtToken(User user)
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),         // NameIdentifier = id
        new Claim(ClaimTypes.Name,user.UserName)
      };  
      var roles = await _userManager.GetRolesAsync(user);

      foreach (var role in roles)
      {
          claims.Add(new Claim(ClaimTypes.Role,role)); // теперь токен будет иметь roles в том числе
      }
      var key = new SymmetricSecurityKey(Encoding.UTF8
        .GetBytes(_config.GetSection("AppSettings:Token").Value));

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
      //создам токен
      var tokenDescriptor = new SecurityTokenDescriptor
      {
         Subject = new ClaimsIdentity(claims),
         Expires = DateTime.Now.AddDays(1),
         SigningCredentials = creds
      };
      //прописываем handler, который позволит создавать token основаном на tokenDescriptor
      var tokenHandler = new JwtSecurityTokenHandler();

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}