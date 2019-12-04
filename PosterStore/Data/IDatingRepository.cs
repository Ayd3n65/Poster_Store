using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PosterStore.Models;

namespace PosterStore.Data
{
    public interface IDatingRepository
    {
         void Add<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();
        Task<IEnumerable<Poster>> GetPosters();
        Task<Poster> GetPoster(int id); 
        Task<Poster> CreatePoster(Poster poster); 


    }
}