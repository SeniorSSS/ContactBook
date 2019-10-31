using ContactBook.Core.Models;
using ContactBook.Core.Services;
using ContactBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IContactBookDbContext context) : base(context) { }
        public virtual ServicesResult Create(T entity)
        {
            return Create<T>(entity);
        }
        public virtual ServicesResult Delete(T entity)
        {
            return Delete<T>(entity);
        }
        public virtual bool Exists(int id)
        {
            return QueryById(id).Any();
        }
        public virtual IEnumerable<T> Get()
        {
            return Get<T>();
        }
        public virtual async Task<T> GetById(int id)
        {
            return await GetById<T>(id);
        }
        public virtual IQueryable<T> Query()
        {
            return Query<T>();
        }
        public virtual IQueryable<T> QueryById(int id)
        {
            return Query<T>().Where(t => t.Id == id);
        }

        public virtual ServicesResult Update(T entity)
        {
            return Update<T>(entity);
        }
    }
}
