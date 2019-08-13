using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Slick.Database;
using Slick.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Slick.Repositories
{
    public class EntityRepository<T>:IEntityRepository<T> where T: BaseEntity, new()
    {
        private readonly ApplicationDbContext entitiesContext;

        public EntityRepository(ApplicationDbContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }

        public T Create(T obj)
        {
            entitiesContext.Set<T>().Add(obj);
            entitiesContext.SaveChanges();
            return obj;
        }

        public void Delete(T obj)
        {
            EntityEntry dbEntity = entitiesContext.Entry<T>(obj);
            dbEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            entitiesContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return entitiesContext.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) {
            return entitiesContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties) {
        IQueryable<T> query = entitiesContext.Set<T>();
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            var sql = query.ToString();
            return query;
        }

        public T GetById(Guid id)
        {
            var item = GetAll().Where(s => s.Id == id).SingleOrDefault();
            return item;
        }

        public void Update(T level)
        {
            EntityEntry dbEntity = entitiesContext.Entry<T>(level);
            dbEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            entitiesContext.SaveChanges();
        }
    }
}
