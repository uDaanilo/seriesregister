using System.Collections.Generic;

namespace series.Interfaces
{
    public interface IRepository<T> {
        List<T> List();
        T getById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int nextId();
    }
}