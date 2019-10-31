using ContactBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Services
{
    public interface IDbService
    {
        IQueryable<T> Query<T>() where T : Entity;
        IQueryable<T> QueryById<T>(int id) where T : Entity;
        IEnumerable<T> Get<T>() where T : Entity;
        Task<T> GetById<T>(int id) where T : Entity;
        ServicesResult Create<T>(T entity) where T : Entity;
        ServicesResult Delete<T>(T entity) where T : Entity;
        ServicesResult Update<T>(T entity) where T : Entity;
        bool Exists<T>(int id) where T : Entity;
    }
}
