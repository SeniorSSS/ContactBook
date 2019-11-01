using ContactBook.Core.Models;
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
    }
}
