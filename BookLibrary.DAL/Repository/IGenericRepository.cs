using System.Collections.Generic;

namespace BookLibrary.DAL.Repository
{

    // TEntity - будь-яка сутність БД
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
