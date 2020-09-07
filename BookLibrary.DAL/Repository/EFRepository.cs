using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookLibrary.DAL.Repository
{
    public class EFRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private static DbContext context;
        private readonly DbSet<TEntity> set;

        public static DbContext GetInstance()
        {
            if (context == null)
            {
                context = new ApplicationContext();
            }
            return context;
        }

        public EFRepository()
        {
            context = EFRepository<TEntity>.GetInstance();
            set = context.Set<TEntity>();
        }
        // Book entity
        public void Create(TEntity entity)
        {
            set.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            set.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return set.AsEnumerable();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            //set.AddOrUpdate(entity);
            context.SaveChanges();
        }
    }
}
