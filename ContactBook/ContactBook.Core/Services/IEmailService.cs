using ContactBook.Core.Models;
using ContactBook.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Services
{
    public interface IEmailService
    {
        Task<IEnumerable<Emails>> GetEmails();

        Task<ServicesResult> AddEmail(Emails email);

        Task<IEnumerable<Emails>> GetEmailsById(int id);

        Task<IEnumerable<EmailRequest>> GetEmailsOnlyByContactId(int id);

        Task<ServicesResult> DeleteEmailById(int id);
        Task DeleteEmailsByContactId(int id);
        Task<ServicesResult> UpdateEmail(Emails email);
        Task<Emails> GetEmail(int id);
        Task<IEnumerable<ContactRequest>> SearchEmails(string search);
    }

}
