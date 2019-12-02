using Microsoft.EntityFrameworkCore;
using PosterStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosterStore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base(options)
        {

        }
        public  DbSet<Value> MyProperty { get; set; }
        public DbSet<User> Users {get; set;}   
        public DbSet<Poster> Posters {get; set;}
        public DbSet<PosterImage> PosterImages {get; set;}


    }
}
