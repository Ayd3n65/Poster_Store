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

namespace PosterStore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly IAuthRepository _repo;
    private readonly IConfiguration _config;
    public AccountController(IAuthRepository repo, IConfiguration config)
    {
      _config = config;
      _repo = repo;

    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
    {
      // валидация 
      userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

      if (await _repo.UserExists(userForRegisterDto.Username))
        return BadRequest("Пользователь уже существует");
      var userToCreate = new User
      {
        UserName = userForRegisterDto.Username
      };
      var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
      return StatusCode(201);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {
      var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
      if (userFromRepo == null)
        return Unauthorized();
      // Создаем токен который потом отправим юзеру, он будет содержать 2-битную инф о юзере(username и password) 
      //Так как токен валидирован сервером без использования бд,сервер сможет заглянуть внутрь токена и получит данные о юзере
      var claims = new[]
      {
        new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),         // NameIdentifier = id
        new Claim(ClaimTypes.Name,userFromRepo.UserName)
      };
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
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
      return Ok(new {
        token = tokenHandler.WriteToken(token) // отправляем токен в response 
      });
    }
  }
}