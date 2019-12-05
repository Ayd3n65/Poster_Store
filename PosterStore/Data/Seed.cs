using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using PosterStore.Models;

namespace PosterStore.Data
{
  public class Seed
  {
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager;
    public Seed(DataContext context, UserManager<User> userManager)
    {
      _userManager = userManager;
      _context = context;

    }
    public void SeedPosters()
    {
      var posterData = System.IO.File.ReadAllText("Data/posterSeedData.json");
      var posters = JsonConvert.DeserializeObject<List<Poster>>(posterData);
      foreach (var poster in posters)
      {
        _context.Posters.Add(poster);
      }
      _context.SaveChanges();
    }
    public void SeedUsers()
    {
      if (!_userManager.Users.Any())
      {
        var userData = System.IO.File.ReadAllText("Data/userSeedData.json");
        var users = JsonConvert.DeserializeObject<List<User>>(userData);
        foreach (var user in users)
        {
          _userManager.CreateAsync(user, "password").Wait();
        }

      }
    }
  }
}