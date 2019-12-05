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
    private readonly RoleManager<Role> _roleManager;
    public Seed(DataContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
      _roleManager = roleManager;
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
        var roles = new List<Role>
        {
          new Role{Name = "Client"},
          new Role{Name = "Admin"},
          new Role{Name = "Moderator"},

        };
        foreach (var role in roles)
        {
            _roleManager.CreateAsync(role).Wait();  
        }
        foreach (var user in users)
        {
          _userManager.CreateAsync(user, "password").Wait();
          _userManager.AddToRoleAsync(user,"Client").Wait();
        }
        var adminUser = new User
        {
          UserName = "Admin"
        };
        IdentityResult result = _userManager.CreateAsync(adminUser,"password").Result;
        if(result.Succeeded)
        {  
         var admin = _userManager.FindByNameAsync("Admin").Result;
          _userManager.AddToRolesAsync(admin, new[] {"Admin", "Moderator"}).Wait();
        }

      }
    }
  }
}