using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Cache;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public readonly IHostingEnvironment _hostingEnvironment;
    private readonly DataContext _context;

    public PostersController(IDatingRepository repo, IMapper mapper, IHostingEnvironment hostingEnvironment, DataContext context)
    {
      _context = context;
      _mapper = mapper;
      _repo = repo;
      _hostingEnvironment = hostingEnvironment;

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

    [HttpPost("createPoster")]
    public async Task<IActionResult> CreatePoster(PosterForRegisterDto posterForRegisterDto)
    {
      posterForRegisterDto.Title = posterForRegisterDto.Title;
      var posterToCreate = new Poster
      {
        Title = posterForRegisterDto.Title,
        Description = posterForRegisterDto.Description,
        Size = posterForRegisterDto.Size,
        Price = posterForRegisterDto.Price
      };
       var createdPoster = await _repo.CreatePoster(posterToCreate);
      // _context.Add(posterToCreate);
      // await _context.SaveChangesAsync();
      return StatusCode(201);
    }
  }
}


// if (posterForRegisterDto.Photos != null && posterForRegisterDto.Photos.Count > 0){
//  var posterToCreate = new Poster
//   {
//     Title = posterForRegisterDto.Description,
//     Description = posterForRegisterDto.Title,
//     Size = posterForRegisterDto.Size,
//     Price = posterForRegisterDto.Price
//   };
//    foreach (IFormFile photo in posterForRegisterDto.Photos)
//    {
//     string uniqueFileName = null;
//     string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/posters");

//     uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
//     string filePath = Path.Combine(uploadsFolder, uniqueFileName);

//     photo.CopyTo(new FileStream(filePath, FileMode.Create));
//     PosterImage imPoster = new PosterImage
//     {
//       Poster =  posterToCreate,
//       Url = uniqueFileName

//     };
//     var createdPoster = await _repo.RegisterPoster(posterToCreate,imPoster);

//    }
//    await _repo.SaveAll();
// }
//     return StatusCode(201);