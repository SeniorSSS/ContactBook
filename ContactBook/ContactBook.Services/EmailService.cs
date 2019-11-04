using ContactBook.Core.Models;
using ContactBook.Core.Services;
using ContactBook.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Linq;
using ContactBook.Services.Models;

namespace ContactBook.Services
{
    public class EmailService : EntityService<Emails>, IEmailService
    {
        public EmailService(IContactBookDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Emails>> GetEmails()
        {
            return await Task.FromResult(Get());
        }

        public async Task<ServicesResult> AddEmail(Emails email)
        {
            return Create(email);
        }

        public async Task<IEnumerable<Emails>> GetEmailsById(int id)
        {
            var emails = Query().Where(e => e.Contact.Id == id);
            return await emails.ToListAsync();
        }

        public async Task<IEnumerable<EmailRequest>> GetEmailsOnlyByContactId(int id)
        {
            var emailsReq = Query().Where(e => e.Contact.Id == id)
                .Select(e => new EmailRequest {
                                    //ja nu savaigās tomēr contactId frontendā, kaut gan tur jau jābūt tikai vienam ContactId visam
                                    //ContactId = e.Contact.Id,
                                    Id = e.Id,
                                    Email = e.Email
                                });

            return await emailsReq.ToListAsync();
        }

        public async Task<Emails> GetEmail(int id)
        {
            return await GetById(id);
        }

        public async Task<ServicesResult> DeleteEmailById(int id)
        {
            var email = await GetById(id);
            return email == null ? new ServicesResult(true) : Delete(email);
        }

        public async Task DeleteEmailsByContactId(int id)
        {
           var emailsToDelete = await GetEmailsById(id);
            _ctx.Emails.RemoveRange(emailsToDelete);
        }

        public async Task<ServicesResult> UpdateEmail(Emails email)
        {
            return email == null ? new ServicesResult(true) : Update(email);       
        }

    }
}