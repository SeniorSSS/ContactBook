using ContactBook.Core.Models;
using ContactBook.Core.Services;
using ContactBook.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Linq;


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

    }
}