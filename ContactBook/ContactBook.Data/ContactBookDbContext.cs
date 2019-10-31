using ContactBook.Core.Models;
using ContactBook.Data.Migrations;
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
        public ContactBookDbContext() : base("Contact-Book")
        {
            Database.SetInitializer<ContactBookDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContactBookDbContext, Configuration>());
        }

        public DbSet<PhoneNumbers> PhoneNumbers { get; set; }
        public DbSet<PhoneTypes> PhoneTypes { get; set; }
        public DbSet<Core.Models.Companies> Companies { get; set; }
        public DbSet<Core.Models.Addresses> Addresses { get; set; }
        public DbSet<Core.Models.Emails> Emails { get; set; }
        public DbSet<Core.Models.Contacts> Contacts { get; set; }


    }
}
