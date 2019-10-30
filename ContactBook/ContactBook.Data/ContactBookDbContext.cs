using ContactBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Data
{
    public class ContactBookDbContext : DbContext, IContactBookDbContext
    {
/*        public ContactBookDbContext() : base("Contact-Book")
        {
            Database.SetInitializer<ContactBookDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContactBookDbContext, Configuration>());
        }*/

        public DbSet<PhoneNumbers> PhoneNumbers { get; set; }
        public DbSet<PhoneTypes> PhoneTypes { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Emails> Emails { get; set; }
        public DbSet<Contacts> Contacts { get; set; }


    }
}
