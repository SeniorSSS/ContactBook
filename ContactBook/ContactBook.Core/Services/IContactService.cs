using ContactBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contacts>> GetContacts();
        Task<ServicesResult> AddContact(Contacts contact);
    }
}
