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
        Task<Contacts> GetContactById(int id);
        Task<ServicesResult> DeleteContactById(int id);
        Task<ServicesResult> UpdateContact(Contacts contact);
        Task<IEnumerable<ContactRequest>> GetContactsNames();
        Task<IEnumerable<ContactRequest>> SearchContacts(string search);
        Task Clear();
    }
}
