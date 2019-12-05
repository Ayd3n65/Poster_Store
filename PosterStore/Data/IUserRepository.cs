using System.Collections.Generic;
using System.Threading.Tasks;
using PosterStore.Helpers;
using PosterStore.Models;


namespace PosterStore.Data
{
    public interface IUserRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<User> GetUser(int id,bool isCurrentUser);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> SaveAll();

    }
}