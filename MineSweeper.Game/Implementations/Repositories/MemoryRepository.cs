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

        public void Delete(T entity)
        {
            foreach (var item in _entities)
            {
                var found = true;
                foreach (var property in entity.GetType().GetProperties())
                {
                    {
                        var value1 = property.GetValue(entity);
                        var value2 = property.GetValue(item);
                        if (!value1.Equals(value2))
                        {
                            found = false;
                        }
                    }
        
                }
                if (found == true)
                {
                    _entities.Remove(item);
                    return;
                }
            }
        }
    }
}
