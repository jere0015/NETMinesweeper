using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MineSweeper.Game
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> Items()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            _dbContext.Add<T>(entity);

            _dbContext.SaveChanges();
        }
    }
}
