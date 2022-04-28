namespace MineSweeper.Game
{
    public class MemoryRepository<T> : IRepository<T> where T : class
    {
        private List<T> _entities = new List<T>();

        public IEnumerable<T> Items()
        {
            return _entities;
        }

        public void Create(T entity)
        {
            _entities.Add(entity);
        }
    }
}
