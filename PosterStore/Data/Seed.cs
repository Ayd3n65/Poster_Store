using System.Collections.Generic;
using Newtonsoft.Json;
using PosterStore.Models;

namespace PosterStore.Data
{
  public class Seed
  {
    private readonly DataContext _context;
    public Seed(DataContext context)
    {
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
  }
}