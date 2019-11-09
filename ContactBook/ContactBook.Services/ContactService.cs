using ContactBook.Core.Models;
using ContactBook.Core.Services;
using ContactBook.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ContactBook.Services
{
    public class ContactService : EntityService<Contacts>, IContactService
    {
        public ContactService(IContactBookDbContext context) : base(context) { }
        public async Task<IEnumerable<Contacts>> GetContacts()
        {
            return await Task.FromResult(Get());
        }

        public async Task<IEnumerable<ContactRequest>> GetContactsNames()
        {
            var contacts = Query().Where(c => c == c).
                Select(c => new ContactRequest {
                    Id = c.Id,
                    Name = c.Name
                });

            return await contacts.ToListAsync();
        }

        public async Task<ServicesResult> AddContact(Contacts contact)
        {
            return Create(contact);
        }

        public async Task<Contacts> GetContactById(int id)
        {
            return await GetById(id);
        }

        public async Task<ServicesResult> UpdateContact(Contacts contact)
        {
            // var co = await GetById(emailReq.Id);
            // email.Email = emailReq.Email;

            //  return email == null ? new ServicesResult(true) : Update(email);

            var updatedContact = await GetById(contact.Id);
            updatedContact.Name = contact.Name;
            updatedContact.Company = contact.Company;
            updatedContact.Note = contact.Note;
            updatedContact.Birthday = contact.Birthday;

            return contact == null ? new ServicesResult(true) : Update(updatedContact);
        }

        public async Task<ServicesResult> DeleteContactById(int id)
        {
            var contact = await GetById(id);

            //var emailsToDelete = Query().Where

           // _ctx.Emails.Where()

            //var emailsToDelete = 

            return contact == null ? new ServicesResult(true) : Delete(contact);
        }

        public async Task Clear()
        {
            _ctx.Addresses.RemoveRange(_ctx.Addresses);
            _ctx.PhoneNumbers.RemoveRange(_ctx.PhoneNumbers);
            _ctx.PhoneTypes.RemoveRange(_ctx.PhoneTypes);
            _ctx.Emails.RemoveRange(_ctx.Emails);
            _ctx.Contacts.RemoveRange(_ctx.Contacts);
            
            await _ctx.SaveChangesAsync();
        }

    }
}
