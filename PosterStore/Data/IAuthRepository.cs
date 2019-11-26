using System.Threading.Tasks;
using PosterStore.Models;

namespace PosterStore.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password); 
         Task<User> Login(string username,string password);
         Task<bool> UserExists(string username);
    }
}