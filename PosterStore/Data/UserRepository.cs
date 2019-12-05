using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosterStore.Models;

namespace PosterStore.Data
{
  public class UserRepository : IUserRepository
  {
    private readonly DataContext _context;
    public UserRepository(DataContext context)
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

    public async Task<User> GetUser(int id,bool isCurrentUser)
    {
       var query = _context.Users.AsQueryable();

        if (isCurrentUser)
            query = query.IgnoreQueryFilters();

        var user = await query.FirstOrDefaultAsync(u => u.Id == id);
        return user;

    }
    public async Task<IEnumerable<User>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
         return users;   
         
    }

    public Task<bool> SaveAll()
    {
      throw new System.NotImplementedException();
    }
  }
}