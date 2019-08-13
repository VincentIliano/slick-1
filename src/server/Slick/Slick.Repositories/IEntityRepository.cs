using Slick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Slick.Repositories
{
    public interface IEntityRepository<T> where T: class, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T GetById(Guid id);
        T GetById(Guid id, params Expression<Func<T, object>>[] includeProperties);
        T Create(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
