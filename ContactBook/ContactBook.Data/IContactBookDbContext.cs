using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Core.Models;

namespace ContactBook.Data
{
    public interface IContactBookDbContext
    {
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<PhoneNumbers> PhoneNumbers { get; set; }
        DbSet<PhoneTypes> PhoneTypes { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
