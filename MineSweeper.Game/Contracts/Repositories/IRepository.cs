using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Items();

        void Create(T entity);

        void Delete(T entity);
    }
}
