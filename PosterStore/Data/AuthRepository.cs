using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosterStore.Models;

namespace PosterStore.Data
{
  public class AuthRepository : IAuthRepository
  {
    public readonly DataContext _context;

    public AuthRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<User> Login(string username, string password)
    {
      var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
      if (user == null) return null;
      if (!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt)) return null;

      return user; 
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHesh = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for(int i = 0; i < computedHesh.Length; i++)
            {
                if(computedHesh[i]!= passwordHash[i]) return false;
            }
        }
        return true;
    }

    public async Task<User> Register(User user, string password)
    {
      byte[] passwordHash, passwordSalt;
      CreatePasswordHash(password,out passwordHash, out  passwordSalt);
      //out - Означает reference к переменной изначальной. Если passwordHash Обновится в методе,
      //он так же обновится и в строке обьявления
      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;
      await _context.AddAsync(user);
      await _context.SaveChangesAsync();

      return user;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using(var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }
        
    } 
    public async Task<bool> UserExists(string username)
    {
      if(await _context.Users.AnyAsync(x => x.UserName == username))
         return true;
      return false;
    }
  }
}