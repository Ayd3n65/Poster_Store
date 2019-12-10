using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosterStore.Helpers;
using PosterStore.Models;

namespace PosterStore.Data
{
  public class DatingRepository : IDatingRepository
  {
    public readonly DataContext _context;
    public DatingRepository(DataContext context)
    {
      _context = context;

    }
    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public async Task<Poster> GetPoster(int id)
    {
        var poster = await  _context.Posters.Include(p => p.PosterImages).FirstOrDefaultAsync(u => u.Id == id);
        return poster;
    }

    public async Task<PagedList<Poster>> GetPosters(PosterParams posterParams)
    {
        var posters = _context.Posters.Include(p => p.PosterImages);
        return await PagedList<Poster>.CreateAsync(posters,posterParams.PageNumber,posterParams.PageSize);
    }

    public async Task<Poster> CreatePoster(Poster poster)
    {
      await _context.AddAsync(poster);
      await _context.SaveChangesAsync();
      return poster;
    }

    public async Task<bool> SaveAll()
    {
        return await _context.SaveChangesAsync() > 0; // Если 0 то ничго не сохранилось в базу данных
    }
  }
}