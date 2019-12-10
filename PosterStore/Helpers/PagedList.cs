using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PosterStore.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);  
            // например 13 товаров разбить по  5 ел.
            //Количесто стр =  13 / 5 = 2.6  и через ceiling округляем к большему числу, в итоге по 3 стр нужно
            this.AddRange(items);
        }
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source,int pageNumber, int pageSize) 
        {
            var count = await source.CountAsync(); // возвращаем колич элементов
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(); // считаем сколько нужно пропустить товаров
            // допустим нам нужно перейти на 2 стр
            // PageNumber = 2, (2-1) * 5 = 5
            // Значит пропускаем 5 ел и начинаем счет с 6 ел по 11
            return new PagedList<T>(items, count,pageNumber,pageSize);

        }
    }
}