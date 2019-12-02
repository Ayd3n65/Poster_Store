using System.Collections.Generic;
using System.Net.Cache;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PosterStore.Data;
using PosterStore.Dtos;
using PosterStore.Models;

namespace PosterStore.Controllers
{
  [Route("api/[controller]")]
  public class PostersController : ControllerBase
  {
    public readonly IDatingRepository _repo;
    public readonly IMapper _mapper;
    public PostersController(IDatingRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;

    }

    [HttpGet]
    public async Task<IActionResult> GetPosters()
    {
      var posters = await _repo.GetPosters();
      var postersToReturn = _mapper.Map<IEnumerable<PosterForDetailedDto>>(posters);

      return Ok(postersToReturn);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPoster(int id)
    {
      var poster = await _repo.GetPoster(id);
      var posterToReturn = _mapper.Map<PosterForDetailedDto>(poster);
      return Ok(posterToReturn);
    }
    
     [HttpPost("registerPoster")]
    public async Task<IActionResult> RegisterPoster(PosterForRegisterDto posterForRegisterDto)
    {
      posterForRegisterDto.Title = posterForRegisterDto.Title;
      var posterToCreate = new Poster
      {
        Title = posterForRegisterDto.Title
      };
      var createdPoster = await _repo.RegisterPoster(posterToCreate);
      return StatusCode(201);
    }

    

  }
}